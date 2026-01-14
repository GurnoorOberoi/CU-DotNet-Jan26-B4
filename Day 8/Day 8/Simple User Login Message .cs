using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_8
{
    internal class Simple_User_Login_Message
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple User Login Message Processor");
            Console.WriteLine();
            Console.WriteLine("The program receives one line of input in the following format:\r\n<UserName>|<LoginMessage>\r\n");
            string input = Console.ReadLine();
            string[] data = input.Split('|');
            if(data.Length != 2 )
            {
                return;
            }
            string UserName = data[0];
            string Message = data[1].Trim().ToLower();
            string StandardMessage = "login Successful";
            string status;
            if (!Message.Contains("successful"))
            {
                status = "LOGIN FAILED";
            }
            else if (Message.Equals(StandardMessage))
            {
                status = "LOGIN SUCCESS";
            }
            else
            {
                status = "OGIN SUCCESS (CUSTOM MESSAGE)";
            }
            Console.WriteLine($"{"User",-9} : {UserName}");
            Console.WriteLine($"{"Message",-9} : {Message}");
            Console.WriteLine($"{"Status",-9} : {status}");

        }
    }
}
