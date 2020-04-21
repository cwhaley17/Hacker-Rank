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
            //birthdayCakeCandles(new int[] { 3,2,1,3 }); // returns 2
            var res = timeConversion("07:05:45PM");

            Console.WriteLine(res);

            Console.ReadLine();
        }

        static string timeConversion(string s)
        {
            // take a string in AM/PM and return it in military
            var timeSeperated = s.Split(':');
            if (timeSeperated[timeSeperated.Length - 1].ToLower().Contains("pm"))
            {
                // remove the AM/PM
                timeSeperated[timeSeperated.Length - 1] = timeSeperated[timeSeperated.Length - 1].ToLower().Replace("pm", "");
                //int currentTime = int.Parse(timeSeperated[0]) + 12;
                int currentTime = timeSeperated[0] == "12" ? 12 : int.Parse(timeSeperated[0]) + 12;
                timeSeperated[0] = currentTime.ToString();
            }
            else
            {
                // remove the AM/PM
                timeSeperated[timeSeperated.Length - 1] = timeSeperated[timeSeperated.Length - 1].ToLower().Replace("am", "");
                if (timeSeperated[0].Contains("12")) timeSeperated[0] = "00"; // this fixed nearly all failing test cases. What edge case am I missing?
            }
            return String.Format("{0}:{1}:{2}", timeSeperated[0], timeSeperated[1], timeSeperated[2]);
        }

        static int birthdayCakeCandles(int[] ar)
        {
            // I think we just sort ar and grab the highest value then get a count of the number of entries are equal to that value?
            var sortedInput = ar.ToList();

            sortedInput.Sort();

            int numberOfHighest = sortedInput.Where(x => x == sortedInput[sortedInput.Count() - 1]).Count();

            return numberOfHighest;
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
