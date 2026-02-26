namespace Day25_01_ReadKeyRead
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string PIN = "";
            Console.Write("Enter a 4 digit PIN: ");
            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                char ch = info.KeyChar;
                if (info.Key == ConsoleKey.Enter && PIN.Length == 4)
                {
                    break;
                }
                if (char.IsDigit(ch) && PIN.Length<4)
                {
                    PIN += ch;
                    Console.Write("*");
                }
                else if(info.Key==ConsoleKey.Backspace && PIN.Length > 0)
                {
                    PIN = PIN.Substring(0, PIN.Length - 1);
                    Console.Write("\b \b");
                }
                
            }
            Console.WriteLine();
            Console.WriteLine($"PIN : {PIN}");
        }
    }
}
