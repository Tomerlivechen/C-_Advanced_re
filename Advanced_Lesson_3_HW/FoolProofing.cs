using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_3_HW
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

        public static string ValidFilePath(string message)
        {
            string filepath = "";
            do
            {
                filepath = ValidString(message);
                if (!File.Exists(filepath))
                {
                    Console.WriteLine("File not found");
                }
            } while (!File.Exists(filepath));
            return filepath;
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
            if (
                verifiedNume >= min
                && verifiedNume <= max
                && !String.IsNullOrEmpty(value)
                && isnumeric
            )
            {
                return true;
            }
            else
            {
                Console.WriteLine("Invalid value");
                return false;
            }
        }

        public static void greentext(string text, bool flow)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();

            
        }

        public static void redtext(string text,bool flow)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
            if (!flow) { Devider(0); }
        }

        public static void Bluetext(string text, bool flow)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
            Console.ResetColor();
            if (!flow) { Devider(0); }
        }

        public static void underlinetext(string text)
        {
            Console.WriteLine($"\u001b[4m{text}\u001b[0m");
            Devider(0);
        }
    }
}
