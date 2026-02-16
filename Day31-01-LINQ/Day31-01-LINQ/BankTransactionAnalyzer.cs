using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_01_LINQ
{
    class Transaction { public int Acc; public double Amount; public string Type; public DateTime date; }
    internal class BankTransactionAnalyzer
    {
        static void Main(string[] args)
        {
            var transactions = new List<Transaction>
            {
                new Transaction{Acc=101, Amount=5000, Type="Credit", date = new DateTime(2024,1,12) },
                new Transaction{Acc=101, Amount=2000, Type="Debit", date = new DateTime(2025,2,12) },
                new Transaction{Acc=102, Amount=10000, Type="Debit", date = new DateTime(2024,6,9) }
            };
            //Calculate total balance per account
            var totalBalanece = transactions.GroupBy(t => t.Acc).Select(g => new { Account = g.Key, Balance = g.Sum(t => t.Type == "Credit" ? t.Amount : -t.Amount) });
            Console.WriteLine("Total Balance per Account: ");
            foreach (var item in totalBalanece)
            {
                Console.WriteLine($"{item.Account}: {item.Balance}");
            }
            //List suspicious accounts with total debit > credit
            var suspicious = transactions.GroupBy(t => t.Acc).Where(g => g.Where(t => t.Type == "Debit").Sum(t => t.Amount) > g.Where(t => t.Type == "Credit").Sum(t => t.Amount)).Select(g => g.Key);
            Console.WriteLine("\nSuspicious Accounts: ");
            foreach (var item in suspicious)
            {
                Console.WriteLine(item);
            }
            //Group transactions by month
            var month = transactions.GroupBy(t => new { t.date.Year, t.date.Month });
            Console.WriteLine("\nGroup transactions by month");
            foreach (var item in month)
            {
                Console.WriteLine($"{item.Key.Month}/ {item.Key.Year}");
                foreach (var m in item)
                {
                    Console.WriteLine($"{m.Acc}: {m.Amount}");
                }
            }
            //Find highest transaction amount per account
            var highestTransaction = transactions.GroupBy(t => t.Acc).Select(g => g.OrderByDescending(t => t.Amount).First());
            Console.WriteLine("\nHighest Transaction amount per Account: ");
            foreach (var item in highestTransaction)
            {
                Console.WriteLine($"{item.Acc}: {item.Amount}");
            }
        }
    }
}
