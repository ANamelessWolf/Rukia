using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// The decimal number, 585 = 10010010012 (binary), is palindromic in both bases.
    /// Find the sum of all numbers, less than one million, which are palindromic in base 10 and base 2.
    /// (Please note that the palindromic number, in either base, may not include leading zeros.)
    /// </summary>
    public class DoubleBasePalindrome : ISolution<long>
    {
        /// <summary>
        /// The list of palindromes
        /// </summary>
        public List<long> Palindromes;
        /// <summary>
        /// The number limit
        /// </summary>
        public long Limit;
        /// <summary>
        /// The result
        /// </summary>
        public long Result
        {
            get { return Solve(); }
        }
        /// <summary>
        /// Creates a new double base palindrome
        /// </summary>
        /// <param name="limit">The limit</param>
        public DoubleBasePalindrome(long limit = 1000000)
        {
            this.Limit = limit;
        }
        /// <summary>
        /// Solve the double base palindrome
        /// </summary>
        /// <returns>The sum base of palindromes</returns>
        public long Solve()
        {
            Palindromes = new List<long>();
            String b2;
            for (long i = 1; i <= this.Limit; i++)
            {
                b2 = Convert.ToString(i, 2);
                if (b2.IsPalindrome() && i.IsPalindrome())
                {
                    Console.WriteLine(String.Format("b10: {0}, b2:{1}", i, b2));
                    Palindromes.Add(i);
                }
            }
            return Palindromes.Sum();
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The sum of all numbers, less than one {0}, which are palindromic in base 10 and base 2 is {1}", this.Limit, this.Result);
        }
    }
}
