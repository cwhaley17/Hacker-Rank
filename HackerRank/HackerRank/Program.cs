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
            //plusMinus(new int[] { -4, 3, -9, 0, 4, 1 });
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

            // positive
            Console.WriteLine(getFraction(posCount, arrCount));
            // negative
            Console.WriteLine(getFraction(negCount, arrCount));
            // zeros
            Console.WriteLine(getFraction(zroCount, arrCount));
        }

        private static decimal getFraction(int x, int count)
        {
            // Shoot back a decimal. 
            try
            {
                return Math.Round(Convert.ToDecimal(Convert.ToDecimal(x) / count), 6);
            }
            catch (Exception e)
            {
                return x;
            }
        }
    }
}
