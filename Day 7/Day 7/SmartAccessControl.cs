using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    internal class SmartAccessControl
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Smart Access Control Log Processor");
            Console.WriteLine("Each access attempt is logged as one line of input in the following format:\r\n<GateCode>|<UserInitial>|<AccessLevel>|<IsActive>|<Attempts>\r\n");
            string input = Console.ReadLine();
            string[] data = input.Split('|');
            if(data.Length != 5 )
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }
            string GetCode = data[0];
            if(GetCode.Length != 2 || !char.IsLetter(GetCode[0]) || !char.IsDigit(GetCode[1]))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }
            if (data[1].Length != 1)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }
            char UserInitial = data[1][0];
            if (!char.IsUpper(UserInitial))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }
            if (!byte.TryParse(data[2], out byte AccessLevel) || AccessLevel<1 || AccessLevel>7)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }
            if(!bool.TryParse(data[3], out bool IsActive))
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }
            if (!byte.TryParse(data[4], out byte Attempts) || Attempts > 200)
            {
                Console.WriteLine("INVALID ACCESS LOG");
                return;
            }
            string status;
            if (!IsActive)
            {
                status = "ACCESS DENIED – INACTIVE USER";
            }
            else if (Attempts > 100)
            {
                status = "ACCESS DENIED – TOO MANY ATTEMPTS";
            }
            else if (AccessLevel >= 5)
            {
                status = "ACCESS GRANTED – HIGH SECURITY";
            }
            else
            {
                status = "ACCESS GRANTED – STANDARD";
            }
            Console.WriteLine($"{"Gate",-10}: {GetCode}");
            Console.WriteLine($"{"User",-10}: {UserInitial}");
            Console.WriteLine($"{"Level",-10}: {AccessLevel}");
            Console.WriteLine($"{"Attempts",-10}: {Attempts}");
            Console.WriteLine($"{"Status",-10}: {status}");
        }
    }
}
