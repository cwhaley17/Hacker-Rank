using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            //plusMinus(arr);
            //staircase(n);

            Console.ReadLine();
        }

        // need to maintain a count for across as well as down to monitor how many spaces I need and how many steps down to take
        // n = 4 will look like this
        //    #
        //   ##
        //  ###
        // ####
        static void staircase(int n)
        {
            // print a right aligned tower of # symbols. "Floor" level cannot have spaces
            for (int i = 1; i <= n; i++)
            {
                string stringSpaces = new string(' ', n - i);
                string poundsNeeded = new string('#', i);

                Console.WriteLine(stringSpaces + poundsNeeded);
            }
        }

        static void plusMinus(int[] arr)
        {
            int posCount = 0;
            int negCount = 0;
            int zroCount = 0;
            int arrCount = arr.Count();

            foreach (var x in arr)
            {
                if (x > 0)
                    posCount++;
                else if (x == 0)
                    zroCount++;
                else
                    negCount++;
            }

            // There has to be a much cleaner way to do this. This is so bloated.
            decimal a = Convert.ToDecimal(posCount);
            decimal b = Convert.ToDecimal(negCount);
            decimal c = Convert.ToDecimal(zroCount);

            decimal posDec = Math.Round(Convert.ToDecimal(a / arrCount), 6);
            decimal negDec = Math.Round(Convert.ToDecimal(b / arrCount), 6);
            decimal zroDec = Math.Round(Convert.ToDecimal(c / arrCount), 6);

            // positive
            Console.WriteLine(posDec);
            // negative
            Console.WriteLine(negDec);
            // zeros
            Console.WriteLine(zroDec);
            Console.ReadLine();
        }
    }
}
