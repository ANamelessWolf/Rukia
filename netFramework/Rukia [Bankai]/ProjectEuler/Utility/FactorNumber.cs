using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public struct FactorNumber:IComparable<FactorNumber>
    {
        public int FactorA;
        public int FactorB;
        public long Result;
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("\"{0} x {1} = {2}\"", this.FactorA, this.FactorB, this.Result);
        }
        /// <summary>
        /// Compare the number factors
        /// </summary>
        /// <param name="number">The palindrome number</param>
        /// <returns></returns>
        public int CompareTo(FactorNumber number)
        {
            if (this.Result < number.Result)
                return -1;
            else if (this.Result > number.Result)
                return 1;
            else
                return 0;
        }
    }
}
