using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nameless.Libraries.Rukia.ProjectEuler.Utility;
namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// LargestPalindromeProduct
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    public class LargestPalindromeProduct
    {
        /// <summary>
        /// The result
        /// </summary>
        public FactorNumber Result { get { return SolveBruteForce(); } }
        /// <summary>
        /// The largest palindrome made from the product of two 3-digit numbers.
        /// </summary>
        public LargestPalindromeProduct()
        {
        }
        /// <summary>
        /// Solve the problem
        /// ByForce Brute
        /// </summary>
        /// <returns>The sum result</returns>
        private FactorNumber SolveBruteForce()
        {
            int a = 999, b = 999;
            long res = a * b;
            List<FactorNumber> palindromes = new List<FactorNumber>();
            while (a > 100)
            {
                b--;
                if (b < 100)
                {
                    b = 999;
                    a--;
                }
                if (res.IsPalindrome())
                    palindromes.Add(new FactorNumber() { Result = res, FactorA = a, FactorB = b });
                res = a * b;
            }
            palindromes.Sort();
            return palindromes[palindromes.Count-1];
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The largest palindrome made from the product of \"{0} x {1}\" is {2}", this.Result.FactorA, this.Result.FactorB, this.Result.Result);
        }
    }
}
