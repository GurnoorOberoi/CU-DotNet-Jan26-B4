using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Week2Assessment
{
    internal class Insurance_PremiumSystem
    {
        static void Main(string[] args)
        {
            string[] policyHolderNames = new string[5];
            decimal[] annualPremiums = new decimal[5];
            for(int i = 0; i <5; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Enter the name of the PolicyHolder {i+1}: ");
                    string name = Console.ReadLine();
                    if(!string.IsNullOrWhiteSpace(name))
                    {
                        policyHolderNames[i] = name;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Name cannot be empty. Please re-enter it.");
                    }
                }
                while (true)
                {
                    Console.WriteLine($"Enter the Annual premium amount {policyHolderNames[i]} : ");
                    bool isValid = decimal.TryParse(Console.ReadLine(), out decimal Premiums);
                    if(isValid && Premiums > 0)
                    {
                        annualPremiums[i] = Premiums;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Premium must be greater than 0. Please Re-enter it.");
                    }
                }
            }
            decimal TotalPremium = 0;
            decimal HighestPremium = annualPremiums[0];
            decimal LowestPremium = annualPremiums[0];
            for(int i = 0; i < 5; i++)
            {
                TotalPremium += annualPremiums[i];
                if (annualPremiums[i] > HighestPremium)
                {
                    HighestPremium = annualPremiums[i];
                }
                if (annualPremiums[i] < LowestPremium)
                {
                    LowestPremium = annualPremiums[i];
                }
            }
            decimal AveragePremium = TotalPremium / 5;

            Console.WriteLine("\nINSURENCE PREMIUM SUMMARY");
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"{"Name", -20}{"Premium", -15}{"Category", -10}");
            Console.WriteLine("-----------------------------------");
            for(int i = 0; i < 5; i++)
            {
                string category;
                if (annualPremiums[i] < 10000)
                {
                    category = "LOW";
                }
                else if (annualPremiums[i] <= 25000)
                {
                    category = "MEDIUM";
                }
                else
                {
                    category = "HIGH";
                }
                Console.WriteLine($"{policyHolderNames[i].ToUpper(), -20}" + $"{annualPremiums[i], -15:F2}" 
                    + $"{category , 10}");
            }
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"{"Total Premium", -20}: {TotalPremium:F2}");
            Console.WriteLine($"{"Average Premium",-20}: {AveragePremium:F2}");
            Console.WriteLine($"{"Highest Premium",-20}: {HighestPremium:F2}");
            Console.WriteLine($"{"Lowest Premium",-20}: {LowestPremium:F2}");
        }
    }
}
