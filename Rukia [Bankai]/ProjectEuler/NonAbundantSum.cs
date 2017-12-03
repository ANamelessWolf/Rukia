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
    /// A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, 
    /// the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.
    /// A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
    /// As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24.
    /// By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, 
    /// this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that 
    /// cannot be expressed as the sum of two abundant numbers is less than this limit.
    /// Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
    /// </summary>
    public class NonAbundantSum
    {
        public List<ProperNumber> Numbers;
        public List<ProperNumber> Abundants, OddAbundants, EvenAbundants;
        public List<ProperNumber> Rest;
        /// <summary>
        /// The number Limit
        /// </summary>
        public long Limit;
        /// <summary>
        /// The factorial result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public NonAbundantSum(long limit = 28123)
        {
            this.Limit = limit;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long sum = 0;

            Numbers = new List<ProperNumber>();
            Console.WriteLine("Calculando Números...");
            Numbers.Add(new ProperNumber(1));
            for (int i = 2; i < this.Limit; i++)
                Numbers.Add(new ProperNumber(i));
            Abundants = Numbers.Where<ProperNumber>(X => X.Type == ProperNumberType.Abundant).ToList();
            OddAbundants = Abundants.Where<ProperNumber>(X => X.Number % 2 != 0).ToList();
            EvenAbundants = Abundants.Where<ProperNumber>(X => X.Number % 2 == 0).ToList();
            Rest = new List<ProperNumber>();
            long count = 0;
            foreach (ProperNumber pNum in Numbers)
            {
                if (!pNum.IsSumOfTwoAbundants(Abundants, OddAbundants, EvenAbundants))
                    Rest.Add(pNum);
                count++;
                Console.Clear();
                Console.WriteLine("Processing({0}/{1}) {2:P}", count, Numbers.Count, (double)count / (double)Numbers.Count);
            }
            sum = Rest.Sum<ProperNumber>(X => X.Number);
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return sum;
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("the sum of all the positive integers which cannot be written as the sum of two abundant numbers under {0} is {1}", this.Limit, this.Result);
        }
    }
}
