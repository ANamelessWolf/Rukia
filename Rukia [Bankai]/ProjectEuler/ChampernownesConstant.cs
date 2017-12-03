using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// An irrational decimal fraction is created by concatenating the positive integers:
    /// 0.123456789101112131415161718192021...
    /// It can be seen that the 12th digit of the fractional part is 1.
    /// If dn represents the nth digit of the fractional part, find the value of the following expression.
    /// d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000
    /// </summary>
    public class ChampernownesConstant : ISolution<long>
    {
        /// <summary>
        /// Return the problem result
        /// </summary>
        public long Result
        {
            get { return Solve(); }
        }
        /// <summary>
        /// Solve  the problem
        /// </summary>
        /// <returns>the problem solution</returns>
        public long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int[] indexes = new int[] { 1, 10, 100, 1000, 10000, 100000, 1000000 };
            String Champernownes = String.Empty;
            long num = 1, result = 1, digit;
            int currentIndex = 0, chLength = 0, index;
            while (chLength < indexes[indexes.Length - 1])
            {
                if (chLength + num.ToString().Length >= indexes[currentIndex])
                {
                    index = indexes[currentIndex] - chLength - 1;
                    digit = int.Parse(num.ToString().Substring(index, 1));
                    result *= digit;
                    currentIndex++;
                }
                chLength += num.ToString().Length;
                num++;
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return result;

        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The value of the following expression, d1 × d10 × d100 × d1000 × d10000 × d100000 × d1000000 is {0}", this.Result);
        }
    }
}
