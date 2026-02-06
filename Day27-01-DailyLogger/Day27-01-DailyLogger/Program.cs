namespace Day27_01_DailyLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directory = @"..\..\..\";
            if(!Directory.Exists(directory))
            {
                Console.WriteLine("Directory Does not exist");
            }
            string file = "journal.txt";
            string path = directory + file;
            if (!File.Exists(path))
            {
                Console.WriteLine("File does not exist");
            }
            using StreamWriter sw = new StreamWriter(path,true);
            do
            {
                Console.WriteLine("Enter the Reflection Data: ");
                string data = Console.ReadLine();
                if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
                {
                    break;
                }
                sw.WriteLine(data);
            } while (true);
        }
    }
}
