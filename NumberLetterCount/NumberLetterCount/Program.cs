using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberLetterCount
{
    class Program
    {
        static string[] units = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        static string[] teen = { "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        static string[] tens = { "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        static string AND = " and ";
        static string HUNDRED = " Hundred";
        static string THOUSAND = " Thousand ";
        public static void Main(string[] args)
        {
            int count = 0;
            for (int i = 1; i <= 1000; i++)
            {
                count += ToWord(i).Count(c => !Char.IsWhiteSpace(c));
            }
            Console.WriteLine("Total number of letters in 1 to 1000 written in words is: {0}",count);
            //Console.WriteLine(ToWord(9999));
            Console.ReadKey();
        }

        /// <summary>
        /// Function to return word representation of numbers upto 999999
        /// </summary>
        /// <param name="n"></param>
        /// <param name="andFlag"></param>
        /// <returns></returns>
        public static string ToWord(int n, bool andFlag = true)
        {
            if (n < 100)
                return WordTill99(n);
            string word = "";
            int th = n / 1000;
            int hnd = (n / 100) % 10;
            int rem = n % 100;
            word = (th != 0 ? ToWord(th, false) + THOUSAND : "") + (hnd != 0 ? units[hnd - 1] + HUNDRED : "") + (rem != 0 ? (andFlag ? AND : " ") + WordTill99(rem) : "");
            return word;
        }

        public static string WordTill99(int n)
        {
            string word = "";
            if (n < 10)
            {
                return units[n - 1];
            }
            if (n == 10)
            {
                return tens[0];
            }
            if (n > 10 && n < 20)
            {
                return teen[n - 11];
            }
            if (n >= 20 && n < 100)
            {
                return tens[n / 10 - 1] + (n % 10 == 0 ? "" : " " + units[n % 10 - 1]);
            }
            return word;
        }
    }
}
