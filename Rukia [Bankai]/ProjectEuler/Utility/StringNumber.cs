using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class StringNumber
    {
        String[] ones = new String[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        String[] tens1 = new String[] { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        String[] tens2 = new String[] { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        String[] suffix = new String[] { "hundred", "thousand", "million" };
        /// <summary>
        /// The number value as int
        /// </summary>
        public int Number;
        /// <summary>
        /// The size of the string number without counting spaces or hyphens 
        /// </summary>
        public int Count { get { return this.ToString().Replace(" ", "").Replace("-", "").Length; } }
        /// <summary>
        /// Get the string number
        /// </summary>
        /// <param name="number">The string number</param>
        public StringNumber(int number)
        {
            this.Number = number;
        }
        /// <summary>
        /// Get the string number
        /// </summary>
        /// <returns>The string number</returns>
        public override string ToString()
        {
            return GetString(this.Number);
        }

        private string GetString(int number)
        {
            int n = (int)Math.Abs(number);
            String nStr = String.Empty;
            if (n == 0)
                nStr = "zero";
            else
                nStr = FormatNumber(number);
            return nStr;
        }

        private string FormatNumber(int number)
        {
            int n, res;
            String nStr = String.Empty;
            if (number > (int)Math.Pow(10, 9))
                nStr += "Number to big";
            else if (number > (int)Math.Pow(10, 6) && number < (int)Math.Pow(10, 9))
            {
                n = (int)((double)number / Math.Pow(10, 6));
                res = number - n * (int)Math.Pow(10, 6);
                if (res == 0)
                    nStr += FormatNumber(n) + " " + suffix[2];
                else
                {
                    nStr += FormatNumber(n) + " " + suffix[2] + ", ";
                    if (res < 100)
                        nStr += "and ";
                    nStr += FormatNumber(res);
                }
            }
            else if (number >= (int)Math.Pow(10, 3) && number < (int)Math.Pow(10, 6))
            {
                n = (int)((double)number / Math.Pow(10, 3));
                res = number - n * 1000;
                if (res == 0)
                    nStr += FormatNumber(n) + " " + suffix[1];
                else
                {
                    nStr += FormatNumber(n) + " " + suffix[1] + ", ";
                    if (res < 100)
                        nStr += "and ";
                    nStr += FormatNumber(res);
                }
            }
            else if (number > 99 && number < (int)Math.Pow(10, 3))
            {
                n = (int)((double)number / 100d);
                res = number - n * 100;
                if (res == 0)
                    nStr += FormatNumber(n) + " " + suffix[0];
                else
                {
                    nStr += FormatNumber(n) + " " + suffix[0] + " and ";
                    nStr += FormatNumber(res);
                }
            }
            else if (number > 19 && number < 100)
            {
                n = (int)((double)number / 10d);
                res = number - n * 10;
                if (res == 0)
                    nStr += tens1[n - 1];
                else
                {
                    nStr += tens1[n - 1] + "-";
                    nStr += FormatNumber(res);
                }
                
            }
            else if (number > 10 && number < 20)
            {
                n = number - 10;
                nStr += tens2[n - 1];
            }
            else if (number == 10)
                nStr += tens1[0];
            else if (number > 0)
                nStr += ones[number - 1];
            return nStr;
        }

    }
}
