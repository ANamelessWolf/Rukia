using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{

    /// <summary>
    /// A Pythagorean triplet is a set of three natural numbers, a less than b less than c, for which,
    /// a² + b² = c²
    /// For example {3² + 4² = 5²}  = {9 + 16 = 25 } = {52}
    /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
    /// Find the product abc.
    /// </summary>
    public class SpecialPythagoreanTriplet
    {
        ///<summary>
        /// The Pythagorean Sum
        /// </summary>
        public long PythagoreanSum;
        /// <summary>
        /// The pythagorean A number
        /// </summary>
        public int A;
        /// <summary>
        /// The pythagorean B number
        /// </summary>
        public int B;
        /// <summary>
        /// The pythagorean C number
        /// </summary>
        public int C;
        /// <summary>
        /// The multple sum result
        /// </summary>
        public long Result;
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public SpecialPythagoreanTriplet(long pythagoreanSum = 1000)
        {
            this.PythagoreanSum = pythagoreanSum;
            this.Result = this.Solve();
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            A = 1;
            B = A + 1;
            double sum = 0, c;
            do
            {
                c = Math.Sqrt(B * B + A * A);
                sum = A + B + c;
                if (sum > 1000d)
                {
                    A++;
                    B = A + 1;
                }
                else if (sum != 1000)
                    B++;
            }
            while (sum != this.PythagoreanSum);
            this.C = (int)c;
            return A * B * C;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            
            return String.Format("The product {0}*{1}*{2} is {3}", this.A, this.B, this.C, this.Result);
        }


    }
}
