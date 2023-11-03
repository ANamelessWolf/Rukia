using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    /// Power digit sum
    /// 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
    /// What is the sum of the digits of the number 2^1000?
    /// </summary>
    public class PowerDigitSum : ISolution
    {
        public int Number;
        public int Exp;
        public int Result { get; }

        public PowerDigitSum(int number, int exponent)
        {
            this.Number = number;
            this.Exp = exponent;
            this.Result = this.Solve();
        }

        public string PrintResult()
        {
            return String.Format("The sum of the digits of the number {0}^{1} is {2}", this.Number, this.Exp, this.Result);
        }

        public int Solve()
        {
            BigInteger num = new BigInteger(this.Number);
            var res = BigInteger.Pow(this.Number, this.Exp);
            return res.ToString().ToCharArray().Select(x => int.Parse("" + x)).Sum();
        }
    }
}
