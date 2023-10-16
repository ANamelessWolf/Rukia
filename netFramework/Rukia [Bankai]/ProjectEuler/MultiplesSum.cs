using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// Multiples of 3 and 5
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    public class MultiplesSum
    {
        /// <summary>
        /// The fisrt natural number
        /// </summary>
        public int N1;
        /// <summary>
        /// The second natural number
        /// </summary>
        public int N2;
        /// <summary>
        /// The sum limit
        /// </summary>
        public int Limit;
        /// <summary>
        /// The Number factors
        /// </summary>
        public List<int> Factors;
        /// <summary>
        /// The multple sum result
        /// </summary>
        public int Result { get { return Solve(); } }
        /// <summary>
        /// Define the sum all multiples of naturalN1, or naturalN2 below the superiorLimit
        /// </summary>
        /// <param name="naturalN1">First natural number</param>
        /// <param name="naturalN2">Second natural number</param>
        /// <param name="SuperiorLimit">The sum is below this limit</param>
        public MultiplesSum(int naturalN1 = 3, int naturalN2 = 5, int superiorLimit = 1000)
        {
            this.N1 = naturalN1;
            this.N2 = naturalN2;
            this.Limit = superiorLimit;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private int Solve()
        {
            int count = 1, res = 0;
            this.Factors = new List<int>();
            int a = N1 * count,
                b = N2 * count;
            while (a < Limit || b < Limit)
            {
                //Los factores del primer número
                if (N1 * count < Limit)
                {
                    res += a;
                    this.Factors.Add(a);
                }
                //Los factores del segundo número ignorando los
                //que son factores del primer número
                if (b < Limit && b % N1 != 0)
                {
                    res += b;
                    this.Factors.Add(b);
                }
                count++;
                a = N1 * count;
                b = N2 * count;
            }
            this.Factors.Sort();
            return res;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The sum of all multiples of {0}, or {1} below {2} is {3}", this.N1, this.N2, this.Limit, this.Result);
        }

        //Short Solution
        //private int Solve()
        //{
        //    const int N1 = 3;
        //    const int N2 = 5;
        //    const int LIMIT = 1000;
        //    int count = 1,
        //        res = 0,
        //        a = N1 * count,
        //        b = N2 * count;
        //    while (a < LIMIT || b < LIMIT)
        //    {
        //        if (N1 * count < LIMIT)
        //            res += a;
        //        if (b < LIMIT && b % N1 != 0)
        //            res += b;
        //        count++;
        //        a = N1 * count;
        //        b = N2 * count;
        //    }
        //    return res;
        //}

    }
}
