using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9
{
    internal class WeeklySalesAnalysis
    {
        static void Main(string[] args)
        {
            decimal[] sales = new decimal[7];
            string[] categories = new string[7];
            for(int i = 0; i < sales.Length; i++)
            {
                decimal input;
                while (true)
                {
                    Console.WriteLine($"Enter the sales for Day {i+1}: ");
                    bool isValid = decimal.TryParse(Console.ReadLine(), out input );
                    if(!isValid || input < 0)
                    {
                        Console.WriteLine("Invalid input. Sale must be >=0. Try again");
                    }
                    else
                    {
                        sales[i] = input;
                        break;
                    }
                }
            }
            decimal TotalWeekelySale = 0;
            decimal HighestSale = sales[0];
            int HighestDay = 1;
            decimal LowestSale = sales[0];
            int LowestDay = 1;
            for(int i = 0;i < sales.Length;i++)
            {
                TotalWeekelySale += sales[i];
                if (sales[i] > HighestSale)
                {
                    HighestSale = sales[i];
                    HighestDay = i + 1;
                }
                if(sales[i] < LowestSale)
                {
                    LowestSale = sales[i];
                    LowestDay = i + 1;
                }
            }
            decimal AverageSale = TotalWeekelySale / sales.Length;
            int daysAboveAverage = 0;
            for( int i = 0; i < sales.Length;i++)
            {
                if(sales[i] > AverageSale)
                {
                    daysAboveAverage++;
                }
            }
            for(int i = 0; i<sales.Length; i++)
            {
                if (sales[i] < 5000)
                {
                    categories[i] = "LOW";
                }
                else if(sales[i] <= 15000)
                {
                    categories[i] = "MEDIUM";
                }
                else
                {
                    categories[i] = "HIGH";
                }
            }
            Console.WriteLine("\nWeekly Sales Report");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"{"Total Sales",-20} : {TotalWeekelySale:F2}");
            Console.WriteLine($"{"Average Daily Sales",-20} : {AverageSale:F2}\n");
            Console.WriteLine($"{"Highest Sales",-20} : {HighestSale:F2} (Day{HighestDay})");
            Console.WriteLine($"{"Lowest Sales",-20} : {LowestSale:F2} (Day{LowestSale})\n");
            Console.WriteLine($"{"Days Above Average",-20} : {daysAboveAverage}\n");
            Console.WriteLine("Day-Wise Sales category Summary: ");
            for(int i=0;i<sales.Length;i++)
            {
                Console.WriteLine($"Day {i+1} : {categories[i]}");
            }
        }
    }
}
