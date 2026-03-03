using System.Text;

namespace SaaSArchitect
{
    public abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }
        public abstract decimal CalculateMonthlyBill();
        public override bool Equals(object? obj)
        {
            if(obj is Subscriber other)
            {
                return this.ID == other.ID;
            }
            return false;   
        }
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }
        public int CompareTo(Subscriber other)
        {
            int dateCompare = this.JoinDate.CompareTo(other.JoinDate);
            if(dateCompare != 0)
            {
                return dateCompare;
            }
            return this.Name.CompareTo(other.Name);
        }
    }
    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }
        public override decimal CalculateMonthlyBill()
        {
            return FixedRate*(1+TaxRate);
        }
    }
    class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }
        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }
    public static class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MONTHLY REVENUE REPORT");
            sb.AppendLine($"{"Name",-14}  {"Type",-15}  {"JoinDate",-16}  {"MonthlyBill"}");
            sb.AppendLine("-----------------------------------------------------------------------------------");
            foreach (var item in subscribers) 
            {
                string type = item is BusinessSubscriber ? "Business" : "Consumer";
                sb.AppendLine($"{item.Name,-14} {type,-16} {item.JoinDate.ToShortDateString(),-18} {item.CalculateMonthlyBill()}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Subscriber> sub = new Dictionary<string, Subscriber>();
            sub.Add("biz1@corp.com", new BusinessSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Alpha Corp",
                JoinDate = new DateTime(2023, 5, 1),
                FixedRate = 1000m,
                TaxRate = 0.18m
            });
            sub.Add("Con1@corp.com", new ConsumerSubscriber
            {
                ID = Guid.NewGuid(),
                Name = "Simran",
                JoinDate = new DateTime(2023, 7, 20),
                DataUsageGB = 30,
                PricePerGB = 6
            });
            var sortbyRevenye = sub.OrderByDescending(x=>x.Value.CalculateMonthlyBill()).Select(x=>x.Value).ToList();
            ReportGenerator.PrintRevenueReport(sortbyRevenye);
        }
    }
}
