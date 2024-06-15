﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Classes.Classes
{
    public static class StringExtention
    {
        public static string FirstCapital(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {

                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        public static string FirstCapitalMulti(this string input)
        {
            string output = "";
            if (string.IsNullOrEmpty(input))
            {
                return output;
            }
            string[] pateredInput = input.Split(' ');
            for (int i = 0; i < pateredInput.Length;i++)
            {
               output+= char.ToUpper(pateredInput[i][0]) + pateredInput[i][1..] + " ";

                
            }
            return output;
        }

    }
}