using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// A googol (10^100) is a massive number: one followed by one-hundred zeros; 
    /// 100^100 is almost unimaginably large: one followed by two-hundred zeros. 
    /// Despite their size, the sum of the digits in each number is only 1.
    /// Considering natural numbers of the form, a^b, where a, b less than 100, what is the maximum digital sum?
    /// </summary>
    public class PowerfulDigitSum : ISolution<long>
    {
        public long Result
        {
            get { return this.Solve(); }
        }

        public long Solve()
        {
            BigNumber num;
            long digitSum, longestDigitSum = 0;
            for (long i = 1; i < 100; i++)
                for (long j = 1; j < 100; j++)
                {
                    num = BigOperation.Pow(i, j);
                    digitSum = num.ToString().ToCharArray().Select<Char, long>(x => long.Parse(x.ToString())).Sum();
                    if (digitSum > longestDigitSum)
                        longestDigitSum = digitSum;
                }
            return longestDigitSum;
        }

        public override string ToString()
        {
            return String.Format("Considering natural numbers of the form, a^b, where a, b less than 100, the maximum digital sum is {0}", this.Result);
        }

    }
}
