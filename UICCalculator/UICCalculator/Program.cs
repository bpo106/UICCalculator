using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UICCalculator
{
    class Program
    {
        static int Uic(string s)
        {
            int checkDigit = 0;
            while(s.Length > 0)
            {
                checkDigit += ((1 + s.Length % 2) * (s[0] - 48)) / 10 + ((1 + s.Length % 2) * (s[0] - 48)) % 10;
                s = (s.Length == 1) ? "" : s.Substring(1, s.Length - 1);
            }
            return (10 - (checkDigit % 10)) % 10;
        }

        static bool IsCodeRight (string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] > 57 || s[i] < 48)
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            string s = "";
            while (s.Length != 11 || !IsCodeRight(s))
            {
                Console.WriteLine("Type the numbers in without the check digit:");
                s = Console.ReadLine();
                if (s.Length != 11 || !IsCodeRight(s))
                {
                    Console.WriteLine("Wrong code. Try again.");
                }
            }
            int checkDigit = Uic(s);
            Console.WriteLine("The check digit is {0}.", checkDigit);
            Console.ReadLine();
        }
    }
}
