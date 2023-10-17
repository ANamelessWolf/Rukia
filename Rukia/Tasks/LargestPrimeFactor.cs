using Nameless.Libraries.Rukia.ProjectEuler.Helper;
using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    /// Largest prime factor
    /// The prime factors of 13195 are 5, 7, 13 and 29.
    /// What is the largest prime factor of the number 600851475143 ?
    /// </summary>
    public class LargestPrimeFactor : ISolution
    {
        /// <summary>
        /// The sum limit
        /// </summary>
        public long Number;
        /// <summary>
        /// The task result
        /// </summary>
        public int Result;

        public LargestPrimeFactor(long number = 600851475143)
        {
            this.Number = number;
            this.Result = this.Solve();
        }

        public string PrintResult()
        {
            return String.Format("The largest prime factor of the number {0} is {1}", this.Number, this.Result);
        }

        public int Solve()
        {
            long num = this.Number;
            bool isEven = this.Number % 2 == 0;
            int test = isEven ? 2 : 3;
            int factor = 0;
            int times = 0;
            while (num != 1)
            {
                while (num % test == 0)
                {
                    factor = test;
                    num = num / test;
                }
                test += isEven ? 1 : 2;
                times++;
            }
            return factor;
        }
    }
}
