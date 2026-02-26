using System.Security.Cryptography;
using System.Text;

namespace Day27_02_PortfolioFile
{
    class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; }
        public double GetInterestAmount()
        {
            return Principal * InterestRate / 100;
        }
        public string GetRiskLevel()
        {
            if (InterestRate > 10)
                return "High Risk";
            else if (InterestRate >= 5)
                return "Medium Risk";
            else
                return "Low Risk";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @"..\..\..\Loan.csv";
            Console.OutputEncoding= Encoding.UTF8;
            Console.WriteLine("Enter the client name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Principal: ");
            double principal;
            while (!double.TryParse(Console.ReadLine(), out principal))
            {
                Console.WriteLine("Invalid. Enter again");
            }
            Console.WriteLine("Enter the rate: ");
            double rate;
            while(!double.TryParse(Console.ReadLine(),out rate))
            {
                Console.WriteLine("Invalid. Enter again");
            }
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine($"{name},{principal},{rate}");
            };
            List<Loan> l = new List<Loan>();
            using StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            string line;
            while((line = sr.ReadLine())!=null)
            {
                string[] parts = line.Split(',');
                if (parts.Length != 3)
                    continue;
                string Name = parts[0];
                double.TryParse(parts[1], out principal);
                double.TryParse(parts[2], out rate);
                Loan loan = new Loan()
                {
                    ClientName = Name,
                    Principal = principal,
                    InterestRate = rate
                };
                l.Add(loan);
            }
            Console.WriteLine();
            Console.WriteLine("The Loan Portfolio Manager");
            Console.WriteLine();
            Console.WriteLine($"{"Client",-15}|{"Principal",-15}|{"Interest",-15}|{"Risk"}");
            Console.WriteLine("-----------------------------------------------------------");
            foreach (var item in l)
            {
                Console.WriteLine($"{item.ClientName,-15}" +
                    $"|{item.Principal,-15:C}" +
                    $"|{item.GetInterestAmount(),-15:C}" +
                    $"|{item.GetRiskLevel()}");
            }
        }
    }
}
