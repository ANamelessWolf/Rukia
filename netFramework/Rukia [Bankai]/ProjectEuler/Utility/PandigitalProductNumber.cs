using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class PandigitalProductNumber
    {
        /// <summary>
        /// The first product value
        /// </summary>
        public long FactorA;
        /// <summary>
        /// The second product value
        /// </summary>
        public long FactorB;
        /// <summary>
        /// The product result
        /// </summary>
        public long Result { get { return this.FactorA * this.FactorB; } }
        /// <summary>
        /// The pandigital number size
        /// </summary>
        public int Size;

        public PandigitalProductNumber(int a, int b, int size = 9)
        {
            // TODO: Complete member initialization
            this.FactorA = a;
            this.FactorB = b;
            this.Size = size;
        }
        /// <summary>
        /// True if the number is a pandigital product
        /// </summary>
        public Boolean IsPandigitalProduct
        {
            get
            {
                Char[] ch = (FactorA.ToString() + FactorB.ToString() + Result.ToString()).ToCharArray();
                if (ch.Length == Size)
                {
                    Array.Sort<char>(ch);
                    return new String(ch) == "123456789" ? true : false;
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            List<long> fact = new long[] { this.FactorA, this.FactorB }.ToList();
            fact.Sort();
            return String.Format("\"{0} x {1} = {2}\"", fact[0], fact[1], this.Result);
        }
    }
}
