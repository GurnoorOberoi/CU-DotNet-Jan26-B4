using System.Diagnostics.Metrics;

namespace FInancialPortfolioMgmt
{
    class InvalidFinancialDataException : Exception
    {
        public InvalidFinancialDataException(string message) : base(message) { }
    }
    interface IRiskAssessable
    {
        string GetRiskCategory();
    }

    interface IReportable
    {
        string GenerateReportLine();
    }

    public abstract class FinancialInstrument
    {
        public string InstrumentId { get; set; }
        public string Name { get; set; }
        public DateTime PurchaseDate { get; set; }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Quantity cannot be Negative");
                _quantity = value;
            }
        }

        private decimal _purchasePrice;

        public decimal PurchasePrice
        {
            get { return _purchasePrice; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Purchase Price cannot be Negative");
                _purchasePrice = value;
            }
        }

        private decimal _marketPrice;

        public decimal MarketPrice
        {
            get { return _marketPrice; }
            set
            {
                if (value < 0)
                    throw new InvalidFinancialDataException("Market Price cannot be Negative");
                _marketPrice = value;
            }
        }

        private string _currency;

        public string Currency
        {
            get { return _currency; }
            set
            {
                if (value.Length != 3)
                    throw new InvalidFinancialDataException("Currency must be 3-Letter Code");
                _currency = value.ToUpper();
            }
        }

        public decimal TotalInvestment => Quantity * PurchasePrice;
        public abstract decimal CalculateCurrentValue();
        public virtual string GetInstrumentSummary()
        {
            return $"{InstrumentId} | {Name} | Qty: {Quantity} | Invested: {TotalInvestment:C} | Current: {CalculateCurrentValue():C}";
        }

    }

    public class Equity : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "High";

        public string GenerateReportLine()
            => $"{InstrumentId},Equity,{Name},{Quantity},{PurchasePrice},{MarketPrice},{CalculateCurrentValue()}";
    }

    public class Bond : FinancialInstrument, IRiskAssessable, IReportable
    {
        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;

        public string GetRiskCategory() => "Low";

        public string GenerateReportLine()
            => $"{InstrumentId},Bond,{Name},{Quantity},{PurchasePrice},{MarketPrice},{CalculateCurrentValue()}";
    }

    public class FixedDeposit : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;
    }

    public class MutualFund : FinancialInstrument
    {
        public override decimal CalculateCurrentValue()
            => Quantity * MarketPrice;
    }
    public class Portfolio
    {
        private List<FinancialInstrument> instruments = new List<FinancialInstrument>();
        private Dictionary<string, FinancialInstrument> dic = new Dictionary<string, FinancialInstrument>();
        public void AddInstrument(FinancialInstrument instr)
        {
            if (dic.ContainsKey(instr.InstrumentId))
            {
                throw new InvalidFinancialDataException("Duplicate Instrument ID.");
            }
            instruments.Add(instr);
            dic[instr.InstrumentId] = instr;
        }
        public FinancialInstrument GetInstrumentByID(string id)
        {
            return dic.ContainsKey(id) ? dic[id] : null;
        }

        public void RemoveInstrument(string id)
        {
            if (dic.ContainsKey(id))
            {
                instruments.Remove(dic[id]);
                dic.Remove(id);
            }
        }
        public decimal GetTotalPortfolioValue() =>
            instruments.Sum(i => i.CalculateCurrentValue());
        public List<FinancialInstrument> GetInstrumentsByRisk(string risk) =>
            instruments.OfType<IRiskAssessable>().Where(i => i.GetRiskCategory() == risk)
            .Cast<FinancialInstrument>().ToList();
        public IEnumerable<IGrouping<string, FinancialInstrument>> GroupByType()
        => instruments.GroupBy(i => i.GetType().Name);

        public List<FinancialInstrument> GetAll()
            => instruments;

    }
    public enum TransactionType { Buy, Sell }

    public class Transaction
    {
        public string TransactionId { get; set; }
        public string InstrumentId { get; set; }
        public TransactionType Type { get; set; }
        public int Units { get; set; }
        public DateTime Date { get; set; }

        public void Process(Portfolio portfolio)
        {
            var instrument = portfolio.GetInstrumentByID(InstrumentId);
            if (instrument == null)
                throw new Exception("Instrument not found.");

            if (Type == TransactionType.Buy)
            {
                instrument.Quantity += Units;
            }
            else
            {
                if (Units > instrument.Quantity)
                    throw new InvalidFinancialDataException("Cannot sell more units than owned.");
                instrument.Quantity -= Units;
            }
        }
    }
    public class ReportGenerator
    {
        public static void GenerateConsoleReport(Portfolio portfolio)
        {
            Console.WriteLine("===== PORTFOLIO SUMMARY =====");

            foreach (var group in portfolio.GroupByType())
            {
                decimal totalInvestment = group.Sum(i => i.TotalInvestment);
                decimal currentValue = group.Sum(i => i.CalculateCurrentValue());

                Console.WriteLine($"\nInstrument Type: {group.Key}");
                Console.WriteLine($"Total Investment: {totalInvestment:C}");
                Console.WriteLine($"Current Value: {currentValue:C}");
                Console.WriteLine($"Profit/Loss: {(currentValue - totalInvestment):C}");
            }

            Console.WriteLine($"\nOverall Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");

            var riskGroups = portfolio.GetAll()
                                      .OfType<IRiskAssessable>()
                                      .GroupBy(i => i.GetRiskCategory());

            Console.WriteLine("\nRisk Distribution:");
            foreach (var rg in riskGroups)
                Console.WriteLine($"{rg.Key}: {rg.Count()}");
        }

        public static void GenerateFileReport(Portfolio portfolio)
        {
            string fileName = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

            try
            {
                using StreamWriter sw = new(fileName);

                sw.WriteLine("===== PORTFOLIO REPORT =====");
                sw.WriteLine($"Generated On: {DateTime.Now}");
                sw.WriteLine("----------------------------------");

                foreach (var instrument in portfolio.GetAll())
                    sw.WriteLine(instrument.GetInstrumentSummary());

                sw.WriteLine("----------------------------------");
                sw.WriteLine($"Total Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("File write error: " + ex.Message);
            }
        }
    }
    public class CsvParser
    {
        public static FinancialInstrument ParseFromCsv(string csv)
        {
            var parts = csv.Split(',');

            if (parts.Length != 7)
                throw new InvalidFinancialDataException("Invalid CSV format.");

            FinancialInstrument inst;

            string type = parts[1];

            if (type == "Equity")
                inst = new Equity();
            else if (type == "Bond")
                inst = new Bond();
            else if (type == "FixedDeposit")
                inst = new FixedDeposit();
            else if (type == "MutualFund")
                inst = new MutualFund();
            else
                throw new InvalidFinancialDataException("Unknown instrument type");

            inst.InstrumentId = parts[0];
            inst.Name = parts[2];
            inst.Currency = parts[3];
            inst.Quantity = int.Parse(parts[4]);
            inst.PurchasePrice = decimal.Parse(parts[5]);
            inst.MarketPrice = decimal.Parse(parts[6]);
            inst.PurchaseDate = DateTime.Now;

            return inst;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            try
            {
                Portfolio portfolio = new Portfolio();
                string csv1 = "EQ001,Equity,INFY,INR,100,1500,1650";
                string csv2 = "B001,Bond,GovBond,INR,50,4000,4200";

                portfolio.AddInstrument(CsvParser.ParseFromCsv(csv1));
                portfolio.AddInstrument(CsvParser.ParseFromCsv(csv2));
                Transaction[] transactionsArray =
                {
                new Transaction { TransactionId="T1", InstrumentId="EQ001", Type=TransactionType.Buy, Units=50, Date=DateTime.Now },
                new Transaction { TransactionId="T2", InstrumentId="EQ001", Type=TransactionType.Sell, Units=30, Date=DateTime.Now }
            };

                List<Transaction> transactions = transactionsArray.ToList();

                foreach (var t in transactions)
                    t.Process(portfolio);
                ReportGenerator.GenerateConsoleReport(portfolio);
                ReportGenerator.GenerateFileReport(portfolio);
            }
            catch (InvalidFinancialDataException ex)
            {
                Console.WriteLine("Validation Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}