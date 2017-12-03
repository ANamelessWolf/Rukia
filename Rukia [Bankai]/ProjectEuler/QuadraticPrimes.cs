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
    /// Euler discovered the remarkable quadratic formula:
    /// n² + n + 41
    /// It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. 
    /// However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly 
    /// when n = 41, 41² + 41 + 41 is clearly divisible by 41.
    /// The incredible formula  n² − 79n + 1601 was discovered, which produces 80 primes for the consecutive values n = 0 to 79. 
    /// The product of the coefficients, −79 and 1601, is −126479.
    /// Considering quadratics of the form:
    /// n² + an + b, where |a| less than 1000 and |b| greater than 1000
    /// where |n| is the modulus/absolute value of n
    /// e.g. |11| = 11 and |−4| = 4
    /// Find the product of the coefficients, a and b, 
    /// for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.
    /// </summary>
    public class QuadraticPrimes
    {
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
        public QuadraticPrimes(long limit = 1000)
        {
            this.Limit = limit;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            int A = 0, B = 0, maxCount = 0, n = 0, num;
            List<long> primes;
            PrimeGenerator pG;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            pG = new PrimeGenerator(1000);
            primes = pG.Primes;
            for (int a = -1000; a <= 1000; a++)
                for (int b = -1000; b <= 1000; b++)
                {
                    n = 0;
                    num = n * n + a * n + b;
                    while (primes.Contains(Math.Abs(num)))
                    {
                        n++;
                        if (n > maxCount)
                        {
                            maxCount = n;
                            A = a;
                            B = b;
                            Console.Clear();
                            Console.WriteLine("A:{0} B:{1} Count:{2}", a, b, n);
                        }
                        num = n * n + a * n + b;
                    }
                }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return A * B;

        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0 is {0}", this.Result);
        }
    }
}
