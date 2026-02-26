using System.Text;

namespace VowelsShiftCipher
{
    internal class Program
    {
        public static string VowelLogic(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                if (item == 'a') sb.Append('e');
                else if (item == 'e') sb.Append('i');
                else if (item == 'i') sb.Append('o');
                else if (item == 'o') sb.Append('u');
                else if (item == 'u') sb.Append('a');
                else
                {
                    char next = (char)(item + 1);
                    if (item == 'z')
                        next = 'b';
                    else if ("aeiou".Contains(next))
                        next = (char)(next + 1);
                    sb.Append(next);
                }
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the String: ");
            string result = Console.ReadLine();
            Console.WriteLine(VowelLogic(result));
        }
    }
}
