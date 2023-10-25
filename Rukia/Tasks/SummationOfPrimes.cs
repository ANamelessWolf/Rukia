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
    /// The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
    /// Find the sum of all the primes below two million(2000000).
    /// </summary>
    public class SummationOfPrimes : ILongSolution
    {
        public long Limit { get; }
        public long Sum { get; }

        public SummationOfPrimes(long lessThanNumber)
        {
            this.Limit = lessThanNumber;
            this.Sum = this.Solve();
        }


        public string PrintResult()
        {
            return String.Format("The sum of the primes below {0} is {1}", this.Limit, this.Sum);
        }

        public long Solve()
        {
            long sum = 5;
            int index = 5;
            PrimeTester tester = new PrimeTester();
            while(index <= this.Limit)
            {
                if (tester.IsPrime(index))
                    sum += index;
                index += 2;
            }
            return sum;
        }
    }
}

