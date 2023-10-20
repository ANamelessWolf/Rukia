using Nameless.Libraries.Rukia.ProjectEuler.Helper;
using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utils
{
    public class PrimeTester : MillerRabinHelper<int>, IPrimeTester<int>
    {
        public PrimeTestResult QuickTest(int number)
        {
            int[] first_primes = { 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };
            //Se agilizan las pruebas para algunos elementos del conjunto
            if (number < 2)
                return PrimeTestResult.NOT_PRIME;
            else if (number < 4)
                return PrimeTestResult.IS_PRIME;
            else if (number.IsEven())
                return PrimeTestResult.NOT_PRIME;
            else if (first_primes.Contains(number))
                return PrimeTestResult.IS_PRIME;
            else if (number < first_primes.Max())
                return PrimeTestResult.NOT_PRIME;
            else
                return PrimeTestResult.PROBABLY;
        }

        public bool IsPrime(int number)
        {
            PrimeTestResult testFlag = QuickTest(number);
            if (testFlag == PrimeTestResult.PROBABLY)
                testFlag = MillerRabinTest(new MathHelper(), number, 10);
            return testFlag == PrimeTestResult.IS_PRIME;
        }

        #region Miller Rabin Calculation
        /// <summary>
        /// Find d, for the miller rabin test. 
        /// Where 2^r*d = n-1
        /// And n-1 is and Even number
        /// And r is a natural number
        /// </summary>
        /// <param name="number">The number to test and find d</param>
        /// <param name="math">The math utils</param>
        /// <returns>The d variable</returns>
        protected override int Find_d(IMath<int> math, int number)
        {
            int x = number - 1, r = 1, test = 0;
            while (test == 0)
            {
                test = number % math.Power(2, r);
                if (test == 0)
                    r++;
            }
            return x / math.Power(2, r);
        }
        /// <summary>
        /// Find a, for the miller rabin test. 
        /// Where a is a random number greater than 1 and less than the number to test
        /// </summary>
        /// <param name="number">The number to test and find a</param>
        /// <param name="math">The math utils</param>
        /// <returns>The a variable</returns>
        protected override int Find_a(IMath<int> math, int number)
            => math.NextRandom(2, number);
        /// <summary>
        /// Computes the value of b0 where the b0 = a^d mod n
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="d">d variable calc with the Find_d, function</param>
        /// <param name="a">a variable random number</param>
        /// <param name="number">The number to test</param>
        /// <returns>b0 calculated value</returns>
        protected override int Computeb0(IMath<int> math, int d, int a, int number)
        {
            int x = math.Power(a, d);
            return x % number;
        }
        /// <summary>
        /// Computes the value of bn where the bn = bn_1 mod n
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="bn_1">Last computed bn_1</param>
        /// <param name="number">The number to test</param>
        /// <returns>bn calculated value</returns>
        protected override int Computebn(IMath<int> math, int b0, int number)
        {
            return math.Power(b0, 2) % number;
        }
        /// <summary>
        /// Primality test says a number is composite if bn es equal 1 or -1
        /// </summary>
        /// <param name="math">Math utils if needed</param>
        /// <param name="bn">The computed value of bn</param>
        /// <returns>True if the number is composite</returns>
        protected override bool Testbn(IMath<int> math, int bn)
            => bn == 1 || bn == -1;
        #endregion
    }
}
