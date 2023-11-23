using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    /// Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
    /// If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
    /// For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
    /// Evaluate the sum of all the amicable numbers under 10000.
    /// </summary>
    public class AmicableNumbers : ISolution
    {
        public int Limit;
        public PrimeTester Tester { get; }
        public int Result { get; }

        public AmicableNumbers(int limit)
        {
            this.Limit = limit;
            this.Tester = new PrimeTester();
            this.Result = this.Solve();
        }
        public string PrintResult()
        {
            return String.Format("the sum of all the amicable numbers under {0} is {1}", this.Limit, this.Result);
        }

        public int Solve()
        {
            int sum = 0, b;
            for (int a = 2; a < this.Limit; a++)
            {
                b = SumOfProperDivisors(a);
                if (b > a && SumOfProperDivisors(b) == a)
                    sum += a + b;
            }
            return sum;
        }

        private int SumOfProperDivisors(int a)
            => a.GetFactors(this.Tester).Where(x => x != a).Sum();
    }
}
