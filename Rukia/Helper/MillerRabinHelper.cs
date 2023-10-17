using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;

namespace Nameless.Libraries.Rukia.ProjectEuler.Helper
{
    /// <summary>
    /// This class is used to help calculate the miller
    /// rabin helper
    /// </summary>
    /// <typeparam name="T">The number data type</typeparam>
    public abstract class MillerRabinHelper<T>
    {
        /// <summary>
        /// Find d, for the miller rabin test. 
        /// Where 2^r*d = n-1
        /// And n-1 is and Even number
        /// And r is a natural number
        /// </summary>
        /// <param name="number">The number to test and find d</param>
        /// <param name="math">The math utils</param>
        /// <returns>The d variable</returns>
        protected abstract T Find_d(IMath<T> math, T number);
        /// <summary>
        /// Find a, for the miller rabin test. 
        /// Where a is a random number greater than 1 and less than the number to test
        /// </summary>
        /// <param name="number">The number to test and find a</param>
        /// <param name="math">The math utils</param>
        /// <returns>The a variable</returns>
        protected abstract T Find_a(IMath<T> math, T number);
        /// <summary>
        /// Computes the value of b0 where the b0 = a^d mod n
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="d">d variable calc with the Find_d, function</param>
        /// <param name="a">a variable random number</param>
        /// <param name="number">The number to test</param>
        /// <returns>b0 calculated value</returns>
        protected abstract T Computeb0(IMath<T> math, T d, T a, T number);
        /// <summary>
        /// Computes the value of bn where the bn = bn_1 mod n
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="bn_1">Last computed bn_1</param>
        /// <param name="number">The number to test</param>
        /// <returns>bn calculated value</returns>
        protected abstract T Computebn(IMath<T> math, T bn_1, T number);
        /// <summary>
        /// Primality test says a number is composite if bn es equal 1 or -1
        /// </summary>
        /// <param name="math">Math utils if needed</param>
        /// <param name="bn">The computed value of bn</param>
        /// <returns>True if the number is composite</returns>
        protected abstract bool Testbn(IMath<T> math, T bn);
        /// <summary>
        /// Check if a number is prime, using the primality rabin test
        /// </summary>
        /// <param name="math">Math utils if needed</param>
        /// <param name="number">The number to test</param>
        /// <param name="trials">The number of trials used to test the number</param>
        /// <returns>The prime test result</returns>
        public virtual PrimeTestResult MillerRabinTest(IMath<T> math, T number, int trials)
        {
            PrimeTestResult testFlag = PrimeTestResult.PROBABLY;
            T d = Find_d(math, number);
            T a, bn_1, bn;
            a = Find_a(math, number);
            bn_1 = Computeb0(math, d, a, number);
            bn = bn_1;
            for (int i = 1; i <= trials; i++)
            {
                bn = Computebn(math, bn_1, number);
                if (Testbn(math, bn))
                {
                    testFlag = PrimeTestResult.COMPOSITE;
                    break;
                }
                bn_1 = bn;
            }
            if (!Testbn(math, bn))
                testFlag = PrimeTestResult.IS_PRIME;
            return testFlag;
        }
    }
}
