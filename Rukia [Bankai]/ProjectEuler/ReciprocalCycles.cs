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
    /// A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:
    /// 1/2	    = 	0.5
    /// 1/3	    = 	0.(3)
    /// 1/4	    = 	0.25
    /// 1/5	    = 	0.2
    /// 1/6	    = 	0.1(6)
    /// 1/7	    = 	0.(142857)
    /// 1/8	    = 	0.125
    /// 1/9	    = 	0.(1)
    /// 1/10	= 	0.1
    /// Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.
    /// Find the value of d less than 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
    /// </summary>
    public class ReciprocalCycles
    {
        /// <summary>
        /// The sum result
        /// </summary>
        public int Result { get { return Solve(); } }
        /// <summary>
        /// The reciprocal cycle
        /// </summary>
        public int Limit;
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public ReciprocalCycles(int limit = 1000)
        {
            this.Limit = limit;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private int Solve()
        {
            int d = 0, number = 2;
            FractionCycle fC;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 2; i <= this.Limit; i++)
            {
                fC = new FractionCycle(i);
                if (fC.Count > d)
                {
                    d = fC.Count;
                    number = fC.Num;
                    //Console.Clear();
                    //Console.WriteLine(fC);
                }
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return number;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The longest recurring cycle in its decimal fraction part is {0}", this.Result);
        }
    }
}
