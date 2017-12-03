using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// It is possible to show that the square root of two can be expressed as an infinite continued fraction.
    /// √ 2 = 1 + 1/(2 + 1/(2 + 1/(2 + ... ))) = 1.414213...
    /// By expanding this for the first four iterations, we get:
    /// 1 + 1/2 = 3/2 = 1.5
    /// 1 + 1/(2 + 1/2) = 7/5 = 1.4
    /// 1 + 1/(2 + 1/(2 + 1/2)) = 17/12 = 1.41666...
    /// 1 + 1/(2 + 1/(2 + 1/(2 + 1/2))) = 41/29 = 1.41379...
    /// The next three expansions are 99/70, 239/169, and 577/408, but the eighth expansion, 1393/985, is the first example where the number of digits in the numerator exceeds the number of digits in the denominator.
    /// In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator?
    /// </summary>
    public class SquareRootConvergents : ISolution<long>
    {
        const int NUMBER_OF_EXPANSIONS = 1000;

        public long Result
        {
            get { return this.Solve(); }
        }

        public long Solve()
        {
            long count = 0;
            SquareTwoConvergent con = new SquareTwoConvergent(NUMBER_OF_EXPANSIONS);
            con.AddOne();
            count = con.Fractions.Where(x => x[0].ToString().Length > x[1].ToString().Length).Count();
            return count;
        }

        public override string ToString()
        {
            return String.Format("In the first one-thousand expansions, how many fractions contain a numerator with more digits than denominator is {0}", this.Result);
        }
    }
}
