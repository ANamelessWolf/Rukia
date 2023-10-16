using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
    /// If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?
    /// NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
    /// </summary>
    public class NumberLetterCount
    {
        /// <summary>
        /// The result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// The result
        /// </summary>
        public int Limit;
        /// <summary>
        /// Count all the number letters
        /// </summary>
        public NumberLetterCount(int limit = 1000000)
        {
            this.Limit = limit;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            long count = 0;
            StringNumber s;
            for (int i = 1; i <= this.Limit; i++)
            {
                
                s = i.ToNumberName();
                Console.Clear();
                Console.WriteLine(s);
                count += s.Count;
            }
            return count;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The numbers from 1 to 1000 inclusive written in words, had a total of {0}", this.Result);
        }
    }
}
