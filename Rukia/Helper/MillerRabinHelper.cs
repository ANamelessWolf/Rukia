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
        /// <param name="n">The number to test and find d</param>
        /// <param name="math">The math utils</param>
        /// <returns>The d variable</returns>
        protected abstract T Find_d(IMath<T> math, T n);
        /// <summary>
        /// Find a, for the miller rabin test. 
        /// Where a is a random number greater than 1 and less than the number to test
        /// </summary>
        /// <param name="n">The number to test and find a</param>
        /// <param name="math">The math utils</param>
        /// <returns>The a variable</returns>
        protected abstract T Find_a(IMath<T> math, T n);
        /// <summary>
        /// Computes the value of x where the x = a^d mod n
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="d">d variable calc with the Find_d, function</param>
        /// <param name="a">a variable random number</param>
        /// <param name="n">The number to test</param>
        /// <returns>x calculated value</returns>
        protected abstract T ComputeX(IMath<T> math, T d, T a, T n);
        /// <summary>
        /// Computes the value of x where x = (x*x) % n
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="x">The last x calculated value</param>
        /// <param name="n">The number to test</param>
        /// <returns>x calculated value</returns>
        protected abstract T ComputeX(IMath<T> math, T x, T n);
        /// <summary>
        /// Multiplys d by 2
        /// </summary>
        /// <param name="d">d variable calc with the Find_d, function</param>
        /// <returns>d multiplication result</returns>
        protected abstract T MultiplyBy2(T d);
        /// <summary>
        /// Evaluates the boolean operation
        /// x == 1 || x == number - 1
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="x">X evaluated</param>
        /// <param name="number">The number to test</param>
        /// <returns>True if the condition are met</returns>
        protected abstract bool EvaluateX(IMath<T> math, T x, T number);
        /// <summary>
        /// Test x to see if the number is not prime
        /// x != n-1
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="x">X evaluated</param>
        /// <param name="number">The number to test</param>
        /// <returns>True if the condition are met</returns>
        protected abstract bool TestXForNotPrime(IMath<T> math, T x, T number);
        /// <summary>
        /// Check the miller rabin test result on x and d
        /// d!= number-1 && x!=1 && x != number-1
        /// </summary>
        /// <param name="math">The math utils</param>
        /// <param name="x">X evaluated</param>
        /// <param name="d">d variable calc with the Find_d, function</param>
        /// <param name="number">The number to test</param>
        /// <returns>True if the condition are met</returns>
        protected abstract bool CheckMillerRabinTest(IMath<T> math, T x, T d, T number);
        /// <summary>
        /// Check if a number is prime, using the primality rabin test
        /// </summary>
        /// <param name="math">Math utils if needed</param>
        /// <param name="number">The number to test</param>
        /// <param name="trials">The number of trials used to test the number</param>
        /// <returns>The prime test result</returns>
        public virtual PrimeTestResult MillerRabinTest(IMath<T> math, T number, int trials)
        {
            T d = Find_d(math, number);
            T a;
            T x;
            for (int i = 1; i <= trials; i++)
            {
                a = Find_a(math, number);
                x = ComputeX(math, d, a, number);
                if (EvaluateX(math, x, number))
                    continue;
                while(CheckMillerRabinTest(math, x, d, number))
                {
                    x = ComputeX(math, x, number);
                    d = MultiplyBy2(d);
                }
                if (TestXForNotPrime(math, x, number))
                    return PrimeTestResult.NOT_PRIME;
            }
            return PrimeTestResult.IS_PRIME;
        }
    }
}
