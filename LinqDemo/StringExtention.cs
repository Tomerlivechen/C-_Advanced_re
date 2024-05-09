using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemo
{
    internal static class StringExtention
    {
        public static string FirstLetterToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
                {

                return input;
                 }

            return char.ToUpper(input[0]) + input.Substring(1);
        }
    }

    internal static class IntExtention
    {
        public static bool IsEven(this int input)
        {
            if (input % 2 ==0)
            {

                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
