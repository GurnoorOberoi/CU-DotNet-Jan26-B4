using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day30_01_ExpenseSharing
{
    internal class Approach2
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("Aman", 900);
            dic.Add("Soman", 0);
            dic.Add("Kartik", 1290);
            int sum = 0;
            foreach (var item in dic)
            {
                sum += item.Value;
            }
            decimal share = sum / dic.Count;
            Console.WriteLine($"Each person should pay: {share}");
            Console.WriteLine();
            foreach (var p in dic)
            {
                decimal diff = p.Value - share;

                if (diff > 0)
                {
                    Console.WriteLine(
                        p.Key + " should receive " + diff);
                }
                else if (diff < 0)
                {
                    Console.WriteLine(
                        p.Key + " should pay " + (-diff));
                }
                else
                {
                    Console.WriteLine(
                        p.Key + " is settled");
                }
            }
            //Prepare lists of payers and receivers
            List<(string name, decimal amount)> payers = new List<(string, decimal)>();
            List<(string name, decimal amount)> receivers = new List<(string, decimal)>();

            foreach (var p in dic)
            {
                decimal diff = p.Value - share;
                if (diff < 0)
                    payers.Add((p.Key, -diff));  // owes money
                else if (diff > 0)
                    receivers.Add((p.Key, diff)); // should receive
            }
            int i = 0, j = 0;

            Console.WriteLine("\nPayment Settlements:");

            while (i < payers.Count && j < receivers.Count)
            {
                decimal amount = Math.Min(payers[i].amount, receivers[j].amount);

                Console.WriteLine($"{payers[i].name} pays {amount} to {receivers[j].name}");
                payers[i] = (payers[i].name, payers[i].amount - amount);
                receivers[j] = (receivers[j].name, receivers[j].amount - amount);

                if (payers[i].amount == 0) i++;
                if (receivers[j].amount == 0) j++;
            }
        }
    }
}
