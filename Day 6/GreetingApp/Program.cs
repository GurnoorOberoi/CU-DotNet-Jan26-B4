using GreetingLibrary;
namespace GreetingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name :");
            string name = Console.ReadLine()!;
            string result = GreetingHelper.GetGreeting(name);
            Console.WriteLine(result);
        }
    }
}
