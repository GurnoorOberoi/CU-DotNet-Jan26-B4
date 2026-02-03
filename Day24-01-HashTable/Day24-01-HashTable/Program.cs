using System.Collections;

namespace Day24_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht.Add(101, "Alice");
            ht.Add(102, "Bob");
            ht.Add(103, "Charlie");
            ht.Add(104, "Diana");
            if (!ht.ContainsKey(105))
            {
                ht.Add(105, "Edward");
            }
            else
            {
                Console.WriteLine("ID already exists");
            }

            string name = (string)ht[102];
            Console.WriteLine("Employee with ID 102 : " + name);
            Console.WriteLine();
            Console.WriteLine("Employee Details");
            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine($"ID: {item.Key}, Name: {item.Value}");
            }
            Console.WriteLine();
            ht.Remove(103);
            Console.WriteLine("Total Employee : " + ht.Count);
        }
    }
}
