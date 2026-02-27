namespace LineMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Display();
            Display('+');
            Display('$', 60);
            printLine();
            printLine(ch: '$');
            printLine(ch: '$', num: 70);
            printLine(75);
            printLine(60, '+');
        }
        static void Display(char ch = '-', int num = 40)
        {
            Console.WriteLine(new string(ch, num));
        }

        static void printLine(int num = 40, char ch = '-')
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }
    }
}