using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// The following iterative sequence is defined for the set of positive integers:
    /// n → n/2 (n is even)
    /// n → 3n + 1 (n is odd)
    /// Using the rule above and starting with 13, we generate the following sequence:
    /// 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
    /// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
    /// Which starting number, under one million, produces the longest chain?
    /// NOTE: Once the chain starts the terms are allowed to go above one million.
    /// </summary>
    public class LongestCollatzSequence
    {
        /// <summary>
        /// The limit
        /// </summary>
        public long Limit;
        /// <summary>
        /// The multple sum result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="limit">The number to extract it prime factor</param>
        public LongestCollatzSequence(long limit = 1000000)
        {
            this.Limit = limit;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            CollatzSequence sq;
            long num = 0, count = 0;

            for (int i = 1; i < this.Limit; i++)
            {
                sq = new CollatzSequence(i);
                sq.Find();
                if (sq.Size > count)
                {
                    num = i;
                    count = sq.Size;
                    //Console.Clear();
                    //Console.WriteLine("Num: " + num);
                    //Console.WriteLine("Size: " + count);
                }
            }
            return num;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The starting number {0}, produces the longest chain number under one million", this.Result);
        }
    }
}
