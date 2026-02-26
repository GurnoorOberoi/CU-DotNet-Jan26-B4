using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    internal class SalesOrderProcessing
    {
        static void Main(string[] args)
        {
            const int Days = 7;
            decimal[] weeklySale = new decimal[Days];
            string[] categories = new string[Days];
            ReadWeeklySales(weeklySale);
            decimal TotalSale = CalculateTotal(weeklySale);
            decimal AverageSale = CalculateAverage(TotalSale, Days);
            int HighestDay, LowestDay;
            decimal HighestSale = FindHighestSale(weeklySale, out HighestDay);
            decimal LowestSale = FindLowestSale(weeklySale, out LowestDay);
            Console.Write("Is this a festival week? (yes/no): ");
            bool isFestivalWeek = Console.ReadLine().ToLower() == "yes";
            decimal Discount = isFestivalWeek
                ? CalculateDiscount(TotalSale, true)
                : CalculateDiscount(TotalSale);
            decimal tax = CalculateTax(TotalSale - Discount);
            decimal FinalAmount = CalculateFinalAmount(TotalSale, Discount, tax);
            GenerateSalesCategory(weeklySale, categories);
            Console.WriteLine("\nWeekly Sales Summary");
            Console.WriteLine("--------------------");
            Console.WriteLine($"Total Sales        : {TotalSale:F2}");
            Console.WriteLine($"Average Daily Sale : {AverageSale:F2}\n");

            Console.WriteLine($"Highest Sale       : {HighestSale:F2} (Day {HighestDay})");
            Console.WriteLine($"Lowest Sale        : {LowestSale:F2}  (Day {LowestDay})\n");
            Console.WriteLine($"Discount Applied   : {Discount:F2}");
            Console.WriteLine($"Tax Amount         : {tax:F2}");
            Console.WriteLine($"Final Payable      : {FinalAmount:F2}\n");
            Console.WriteLine("Day-wise Category:");
            for (int i = 0; i < Days; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}");
            }
        }
        static void ReadWeeklySales(decimal[] sales)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Enter sales for Day {i + 1}: ");
                    bool valid = decimal.TryParse(Console.ReadLine(), out decimal value);

                    if (valid && value >= 0)
                    {
                        sales[i] = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Sales must be non-negative.");
                    }
                }
            }
        }

        static decimal CalculateTotal(decimal[] sales)
        {
            decimal total = 0;
            for (int i = 0; i < sales.Length; i++)
                total += sales[i];

            return total;
        }

        static decimal CalculateAverage(decimal total, int days)
        {
            return total / days;
        }

        static decimal FindHighestSale(decimal[] sales, out int day)
        {
            decimal highest = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] > highest)
                {
                    highest = sales[i];
                    day = i + 1;
                }
            }
            return highest;
        }

        static decimal FindLowestSale(decimal[] sales, out int day)
        {
            decimal lowest = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] < lowest)
                {
                    lowest = sales[i];
                    day = i + 1;
                }
            }
            return lowest;
        }

        // Method Overloading
        static decimal CalculateDiscount(decimal total)
        {
            return total >= 50000 ? total * 0.10m : total * 0.05m;
        }

        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal discount = CalculateDiscount(total);

            if (isFestivalWeek)
                discount += total * 0.05m;

            return discount;
        }

        static decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m;
        }

        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount + tax;
        }

        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                    categories[i] = "Low";
                else if (sales[i] <= 15000)
                    categories[i] = "Medium";
                else
                    categories[i] = "High";
            }
        }
    }
}
