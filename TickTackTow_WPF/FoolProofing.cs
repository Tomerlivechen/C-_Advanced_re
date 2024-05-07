using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTackTow_WPF
{
    internal static class FoolProofing
    {
        public static void Devider(int type)
        {
            if (type == 0)
            {
                Console.WriteLine(
                    "---------------------------------------------------\nPress any key"
                );
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("---------------------------------------------------");
            }
        }


        public static string ValidString(string message)
        {
            string answer;
            do
            {
                Console.WriteLine(message);
                answer = Console.ReadLine();
                if (!String.IsNullOrEmpty(answer))
                {
                    return answer;
                }
                else
                {
                    Console.WriteLine("Invalid value");
                }
            } while (true);
        }


        public static int RequestANumber(string text, int min, int max)
        {
            bool valid;
            do
            {
                Console.WriteLine(text);
                string answer = Console.ReadLine();
                valid = ValueVarification(min, max, answer);
                if (valid)
                {
                    return int.Parse(answer);
                }
            } while (!valid);
            return -1;
        }

        static bool ValueVarification(int min, int max, string value)
        {
            bool isnumeric = int.TryParse(value, out int verifiedNume);
            if (verifiedNume >= min && verifiedNume <= max && !String.IsNullOrEmpty(value) && isnumeric)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid value");
                return false;
            }
        }

    }
}
