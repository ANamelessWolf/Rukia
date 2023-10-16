using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class Pandigital09Rule
    {
        /// <summary>
        /// The pandigital number
        /// </summary>
        public Pandigital09 Number;
        /// <summary>
        /// The indexes in the pandigital number
        /// </summary>
        public int[] DigitIndex;
        /// <summary>
        /// The pandigital divisor
        /// </summary>
        public int Divisor;
        /// <summary>
        /// True if the pandigital rule is valid
        /// </summary>
        public Boolean IsDivisible
        {
            get
            {
                int num = 1;
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < DigitIndex.Length; i++)
                    sb.Append(Number.Digits[this.DigitIndex[i]].ToString());
                num = int.Parse(sb.ToString());
                return num % Divisor == 0;
            }
        }
        /// <summary>
        /// Creates a new pandigital 09 rule
        /// </summary>
        /// <param name="divisor">The divisor</param>
        /// <param name="number">The pandigital number</param>
        /// <param name="indexes">The list of indexes</param>
        public Pandigital09Rule(int divisor, Pandigital09 number, params int[] indexes)
        {
            this.Divisor = divisor;
            this.Number = number;
            this.DigitIndex = new int[indexes.Length];
            for (int i = 0; i < indexes.Length; i++)
                this.DigitIndex[i] = (indexes[i] - 1);
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int num = 1;
            for (int i = 0; i < DigitIndex.Length; i++)
                sb.Append(Number.Digits[this.DigitIndex[i]].ToString());
            num = int.Parse(sb.ToString());
            String val = (num % Divisor == 0) ? "Valid Rule" : "Invalid Rule";
            return String.Format("{0} is divisible by {2}; {1}/{2} = {3}: {4}", sb, num, this.Divisor, Math.Round((double)num / (double)Divisor, 2), val);
        }

    }
}
