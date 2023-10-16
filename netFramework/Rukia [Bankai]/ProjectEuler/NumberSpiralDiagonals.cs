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
    /// Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
    /// 21 22 23 24 25
    /// 20  7  8  9 10
    /// 19  6  1  2 11
    /// 18  5  4  3 12
    /// 17 16 15 14 13
    /// It can be verified that the sum of the numbers on the diagonals is 101.
    /// What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?
    /// </summary>
    public class NumberSpiralDiagonals
    {
        /// <summary>
        /// The number Limit
        /// </summary>
        public int Limit;
        /// <summary>
        /// The result
        /// </summary>
        public BigNumber Result { get { return Solve(); } }
        /// <summary>
        /// Get the sum of all spiral members
        /// </summary>
        /// <param name="order">The matrix spiral order</param>
        public NumberSpiralDiagonals(int order = 1001)
        {
            this.Limit = order;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private BigNumber Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SpiralMatrix m = new SpiralMatrix(this.Limit);
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return m.MatrixSum;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The sum of the numbers on the diagonals in a {0} by {0} spiral formed is {1}", this.Limit, this.Result);
        }
    }
}
