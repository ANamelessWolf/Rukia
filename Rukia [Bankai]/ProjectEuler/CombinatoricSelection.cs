using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// There are exactly ten ways of selecting three from five, 12345:
    /// 123, 124, 125, 134, 135, 145, 234, 235, 245, and 345
    /// In combinatorics, we use the notation, 5C3 = 10.
    /// In general,
    /// C(n,r) = n!/ r!(n−r)!, where r ≤ n, n! = n×(n−1)×...×3×2×1, and 0! = 1.
    /// It is not until n = 23, that a value exceeds one-million: C(23,10) = 1144066.
    /// How many, not necessarily distinct, values of  nCr, for 1 ≤ n ≤ 100, are greater than one-million?
    /// </summary>
    public class CombinatoricSelection : ISolution<Double>
    {
        const Double LIMIT = 1000000d;
        public Double Result
        {
            get { return this.Solve(); }
        }

        public Double Solve()
        {
            Double count = 0;
            Combination c = new Combination(0, 0);
            for (Double n = 1; n <= 100; n ++)
                for (Double r = 1; r <= n; r ++)
                {
                    c.Set(n, r);
                    if (c.Calc() > LIMIT)
                        count++;
                }
            return count;
        }
        public override string ToString()
        {
            return String.Format("There are {0} values of  C(n,r), for 1 ≤ n ≤ 100, that are greater than one-million", this.Solve());
        }
    }
}
