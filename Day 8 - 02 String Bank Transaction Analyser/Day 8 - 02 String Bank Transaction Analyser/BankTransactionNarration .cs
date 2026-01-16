using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Day_8___02_String_Bank_Transaction_Analyser
{
    internal class BankTransactionNarration
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bank Transaction Narration Analyzer");
            Console.WriteLine();
            Console.WriteLine("The application must read one line of input in the following pattern:\r\n<TransactionId>#<AccountHolderName>#<TransactionNarration>\r\n");
            string input = Console.ReadLine();
            string[] data = input.Split('#');
            if(data.Length != 3)
            {
                return;
            }
            string transactionId = data[0];
            string accountHolderName = data[1];
            string transactionNarration = data[2];
            transactionNarration = transactionNarration.Trim();
            while(transactionNarration.Contains("  "))
            {
                transactionNarration = transactionNarration.Replace("  ", " ");
            }
            transactionNarration = transactionNarration.ToLower();
            bool hasKeyword = transactionNarration.Contains("deposits") ||
                transactionNarration.Contains("withdrawal") ||
                transactionNarration.Contains("transfer");
            string standardNarration = "cash deposit successful";
            string category;
            if (!hasKeyword)
            {
                category = "NON-FINANCIAL TRANSACTION";
            }
            else if (transactionNarration.Equals(standardNarration))
            {
                category = "STANDARD TRANSACTION";
            }
            else
            {
                category = "CUSTOM TRANSACTION";
            }
            Console.WriteLine($"{"Transaction ID", -15} : {transactionId}");
            Console.WriteLine($"{"Account Holder", -15} : {accountHolderName}");
            Console.WriteLine($"{"Narration",-15} : {transactionNarration}");
            Console.WriteLine($"{"Category",-15} : {category}");
        }
    }
}
