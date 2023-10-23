using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    public class SpecialPythagoreanTriplet : ISolution
    {
        public int Perimeter { get; }

        public int Product { get; }

        /// <summary>
        /// A Pythagorean triplet is a set of three natural numbers, a less than b less than c, for which,
        /// a² + b² = c²
        /// For example {3² + 4² = 5²}  = {9 + 16 = 25 } = {9 + 16 + 25 = 52}
        /// There exists exactly one Pythagorean triplet for which a + b + c = 1000.
        /// Find the product abc.
        /// </summary>
        public SpecialPythagoreanTriplet(int perimeter)
        {
            this.Perimeter = perimeter;
            this.Product = this.Solve();
        }

        public int Solve()
        {
            //Using a parametrisation of Pythagorean triplets
            //We now a < b < c and m > n > 0
            //a = m² − n²
            //b = 2mn
            //c = m² + n²
            //a + b + c = sum
            //Sustituyendo
            //sum/2 = mn + m²

            //1: Calcular m y n
            int s = this.Perimeter / 2;
            int m = 2, n = 1;
            while (Testparametrisation(m, n, s))
            {
                n++;
                if (n >= m)
                {
                    m++;
                    n = 1;
                }
            }

            // 2: Solve triangle sides based on a<b<c
            int a = m * m - n * n;
            int b = 2 * m * n;
            int c = m * m + n * n;

            //3: Find abc product
            return a * b * c;

        }

        private bool Testparametrisation(int m, int n, int s)
            => (m * n + m * m) != s;

        public string PrintResult()
        {
            return String.Format("The product abc is {0}", this.Product);
        }
    }
}
