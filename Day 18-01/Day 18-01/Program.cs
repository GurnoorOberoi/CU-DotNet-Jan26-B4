namespace Day_18_01
{
    class Loan
    {
        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount = decimal.Zero;
            TenureInYears = 0;
        }
        public Loan(string number, string name, decimal amount, int years)
        {
            LoanNumber = number;
            CustomerName = name;
            PrincipalAmount = amount;
            TenureInYears = years;
        }
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }
        public int TenureInYears { get; set; }

        public double CalculateEMI()
        {
            return (double)PrincipalAmount * 0.1 * TenureInYears;
        }

    }
    class HomeLoan : Loan
    {
        public HomeLoan(string number, string name, decimal amount, int years) : base(number, name, amount, years)
        {

        }
        public new double CalculateEMI()
        {
            return ((double)PrincipalAmount * 0.01) * 0.08 * TenureInYears;
        }
    }
    class CarLoan : Loan
    {
        public CarLoan(string number, string name, decimal amount, int years) : base(number, name, amount, years)
        {

        }
        public new double CalculateEMI()
        {
            return ((double)PrincipalAmount + 15000) * 0.09 * TenureInYears;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Loan[] loans = new Loan[4]
       {
            new HomeLoan("1","S1",4500.50m,7),
            new HomeLoan("2","S2",3500.50m,10),
            new CarLoan("1","C1",4550.50m,3),
            new CarLoan("2","C1",5000,11)
       };
            for (int i = 0; i < loans.Length; i++)
            {

                Console.WriteLine(loans[i].CalculateEMI().ToString("N2"));
            }
        }
    }
}
