namespace Day19_02_AbstractOverride
{
    abstract class UtilityBill
    {
        public UtilityBill(int id, string name, decimal consumed, decimal rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = consumed;
            RatePerUnit = rate;
        }
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }
        public abstract decimal CalculateBillAmount();
        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;
        }
        public void PrintBill()
        {
            decimal billAmount = CalculateBillAmount();
            decimal tax = CalculateTax(billAmount); ;
            decimal finalAmount = billAmount + tax;
            Console.WriteLine("UtilityBill Details");
            Console.WriteLine($"Consumer Id - {ConsumerId}");
            Console.WriteLine($"Consumer Name - {ConsumerName}");
            Console.WriteLine($"Units Consumed - {UnitsConsumed}");
            //Console.WriteLine($"Bill Amount - {billAmount}");
            //Console.WriteLine($"Tax - {tax}");
            Console.WriteLine($"Total Payable - {finalAmount}");
            Console.WriteLine();
        }

    }
    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int id, string name, decimal consumed, decimal rate) : base(id, name, consumed, rate)
        {
        }
        public override decimal CalculateBillAmount()
        {
            decimal amount = UnitsConsumed * RatePerUnit;
            if (UnitsConsumed > 300)
            {
                amount += amount * 0.10m;
            }
            return amount;
        }
    }
    class WaterBill: UtilityBill
    {
        public WaterBill(int id, string name, decimal consumed, decimal rate) : base(id, name, consumed, rate)
        {
        }
        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit;
        }
        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.02m;
        }
    }
    class GasBill : UtilityBill
    {
        public GasBill(int id, string name, decimal consumed, decimal rate) : base(id, name, consumed, rate)
        {
        }
        public override decimal CalculateBillAmount()
        {
            return (UnitsConsumed * RatePerUnit) + 150m; 
        }
        public override decimal CalculateTax(decimal billAmount)
        {
            return 0;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<UtilityBill> list = new List<UtilityBill>
            {
                new ElectricityBill(1,"P1",300,5),
                new WaterBill(2,"P2",375,9),
                new GasBill(3,"P3",450.50m,3)
            };
            foreach (var item in list)
            {
                item.PrintBill();
            }
        }
    }
}
