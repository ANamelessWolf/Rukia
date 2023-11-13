using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Test.ProjectEuler
{
    public class FactorialDigitSum : ISolution
    {
        public int Result { get;  }
        public int Number { get; }


        /// <summary>
        /// n! means n × (n − 1) × ... × 3 × 2 × 1
        /// For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
        /// and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
        /// Find the sum of the digits in the number 100!
        /// </summary>
        public FactorialDigitSum(int factorial)
        {
            this.Number = factorial;
            this.Result = this.Solve();
        }

        public string PrintResult()
        {
            return String.Format("The sum of of the digits in the number {0}! is {1}", this.Number, this.Result);
        }

        public int Solve()
        {
            BigInteger num = 1;
            for (int i = 1; i <= this.Number; i++)
                num*= i;
            return num.ToString().ToCharArray().Select(x=> int.Parse(x.ToString())).Sum();
        }
    }
}
