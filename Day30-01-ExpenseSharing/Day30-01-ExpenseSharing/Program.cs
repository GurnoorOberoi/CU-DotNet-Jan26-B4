namespace Day30_01_ExpenseSharing
{
    internal class Program
    {
        static List<string> SettleExpenseShare(Dictionary<string, double> expenses)
        {
            List<string> settlement = new List<string>();
            Queue<KeyValuePair<string, double>> receivers = new Queue<KeyValuePair<string, double>>();
            Queue<KeyValuePair<string, double>> payers = new Queue<KeyValuePair<string, double>>();
            var totalExpense = expenses.Values.Sum();
            var person = expenses.Count;
            var share = totalExpense / person;

            foreach (var item in expenses)
            {
                if (item.Value > share)
                {
                    receivers.Enqueue(new KeyValuePair<string, double>(item.Key, item.Value - share));
                }
                else if (item.Value < share)
                {
                    payers.Enqueue(new KeyValuePair<string, double>(item.Key, Math.Abs(item.Value - share)));
                }
            }
            while (payers.Count > 0 && receivers.Count > 0)
            {
                var payer = payers.Dequeue();
                var receiver = receivers.Dequeue();
                var amount = Math.Min(payer.Value, receiver.Value);
                settlement.Add($"{payer.Key}, {receiver.Key},{amount}");
                if (payer.Value > amount)
                {
                    payers.Enqueue(new KeyValuePair<string, double>(payer.Key, Math.Abs(amount - payer.Value)));
                }
                if (receiver.Value > amount)
                {
                    receivers.Enqueue(new KeyValuePair<string, double>(receiver.Key, Math.Abs(amount - receiver.Value)));
                }
            }
            return settlement;
        }
        static void Main(string[] args)
        {
            Dictionary<string, double> expenses = new Dictionary<string, double>()
            {
                {"Aman", 900},
                {"Soman", 0},
                {"Kartik", 1290}
            };
            List<string> settlement = SettleExpenseShare(expenses); // settlement - from, to , amount
                                                                    //creditors or Debitors
            foreach (var item in settlement)
            {
                Console.WriteLine(item);
            }
        }
    }
}


