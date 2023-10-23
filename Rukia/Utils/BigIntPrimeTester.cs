using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utils
{
    internal class BigIntPrimeTester : MillerRabinHelper<BigInteger>, IPrimeTester<long>
    {
        public PrimeTestResult QuickTest(long number)
        {
            long[] first_primes = { 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            //Se agilizan las pruebas para algunos elementos del conjunto
            if (number < 2)
                return PrimeTestResult.NOT_PRIME;
            else if (number < 4)
                return PrimeTestResult.IS_PRIME;
            else if (number % 2 == 0)
                return PrimeTestResult.NOT_PRIME;
            else if (first_primes.Contains(number))
                return PrimeTestResult.IS_PRIME;
            else if (number < first_primes.Max())
                return PrimeTestResult.NOT_PRIME;
            else if (number % 5 == 0)
                return PrimeTestResult.NOT_PRIME;
            else
                return PrimeTestResult.PROBABLY;
        }

        public bool IsPrime(long number)
        {
            PrimeTestResult testFlag = QuickTest(number);
            if (testFlag == PrimeTestResult.PROBABLY)
                testFlag = MillerRabinTest(new BigIntMathHelper(), (ulong)number, 10);
            return testFlag == PrimeTestResult.IS_PRIME;
        }

        #region Miller Rabin Calculation
        /// <summary>
        /// Find d, for the miller rabin test. 
        /// Where 2^r*d = n-1
        /// And n-1 is and Even number
        /// And r is a natural number
        /// </summary>
        /// <param name="n">The number to test and find d</param>
        /// <param name="math">The math utils</param>
        /// <returns>The d variable</returns>
        protected override BigInteger Find_d(IMath<BigInteger> math, BigInteger n)
        {
            BigInteger d = n - 1;
            while (math.Mod(d, 2) == 0)
                d /= 2;
            return d;
        }
        /// <summary>
        /// Find a, for the miller rabin test. 
        /// Where a is a random number greater than 1 and less than the number to test
        /// </summary>
        /// <param name="n">The number to test and find a</param>
        /// <param name="math">The math utils</param>
        /// <returns>The a variable</returns>
        protected override BigInteger Find_a(IMath<BigInteger> math, BigInteger n)
            => math.NextRandom(2, n - 2);
        /// <summary>
        /// Computes the value of x where the x = a^d mod n
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="d">d variable calc with the Find_d, function</param>
        /// <param name="a">a variable random number</param>
        /// <param name="n">The number to test</param>
        /// <returns>x calculated value</returns>
        protected override BigInteger ComputeX(IMath<BigInteger> math, BigInteger d, BigInteger a, BigInteger n)
            => math.ModPow(a, d, n);
        /// <summary>
        /// Computes the value of x where x = (x*x) % n
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="x">The last x calculated value</param>
        /// <param name="n">The number to test</param>
        /// <returns>x calculated value</returns>
        protected override BigInteger ComputeX(IMath<BigInteger> math, BigInteger x, BigInteger n)
            => (x * x) % n;
        /// <summary>
        /// Multiplys d by 2
        /// </summary>
        /// <param name="d">d variable calc with the Find_d, function</param>
        /// <returns>x calculated value</returns>
        protected override BigInteger MultiplyBy2(BigInteger d)
            => d * 2;
        /// <summary>
        /// Evaluates the boolean operation
        /// x == 1 || x == n - 1
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="x">X evaluated</param>
        /// <param name="n">The number to test</param>
        /// <returns>True if the condition are met</returns>
        protected override bool EvaluateX(IMath<BigInteger> math, BigInteger x, BigInteger n)
            => (x == 1 || x == n - 1);
        /// <summary>
        /// Test x to see if the number is not prime
        /// x != n-1
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="x">X evaluated</param>
        /// <param name="n">The number to test</param>
        /// <returns>True if the condition are met</returns>
        protected override bool TestXForNotPrime(IMath<BigInteger> math, BigInteger x, BigInteger n)
            => x != n - 1;
        /// <summary>
        /// Check the miller rabin test result on x and d
        /// d!= number-1 && x!=1 && x != number-1
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="x">X evaluated</param>
        /// <param name="d">d variable calc with the Find_d, function</param>
        /// <param name="number">The number to test</param>
        /// <returns>True if the condition are met</returns>
        protected override bool CheckMillerRabinTest(IMath<BigInteger> math, BigInteger x, BigInteger d, BigInteger number)
            => d != number - 1 && x != 1 && x != number - 1;
        #endregion
    }
}
