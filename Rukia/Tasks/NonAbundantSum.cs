using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    /// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, 
    /// the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
    /// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
    /// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24.
    /// By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, 
    /// this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that 
    /// cannot be expressed as the sum of two abundant numbers is less than this limit.
    /// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
    /// </summary>
    public class NonAbundantSum : ISolution
    {
        public int Limit { get; }
        public int Result { get; }

        public NonAbundantSum(int limit = 28123)
        {
            this.Limit = limit;
            this.Result = this.Solve();
        }


        public string PrintResult()
        {
            return String.Format("the sum of all the positive integers which cannot be written as the sum of two abundant numbers under {0} is {1}", this.Limit, this.Result);
        }

        public int Solve()
        {
            PrimeTester tester = new PrimeTester();
            // 1: Calculate the abundant numbers under 28123
            AbundantNumberGenerator generator = new AbundantNumberGenerator(12);
            while (generator.Last() == null || generator.Last() < this.Limit)
                generator.Next();
            // 2: Set numbers in an array
            int[] sum = new int[this.Limit + 1];
            for (int i = 0; i < sum.Length; i++)
                sum[i] = i;
            // 3: Combine all abundant sums
            List<int> abundants = generator.Numbers;
            int length = generator.Numbers.Count, index;
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                {
                    index = abundants[i] + abundants[j];
                    if (index < sum.Length)
                        sum[index] = 0;
                }
            return sum.Sum();
        }
    }
}
