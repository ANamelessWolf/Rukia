using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// It can be seen that the number, 125874, and its double, 251748, contain exactly the same digits, but in a different order.
    /// Find the smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits.
    /// </summary>
    public class PermutedMultiples : ISolution<long>
    {
        public long Result
        {
            get { return Solve(); }
        }

        public long Solve()
        {
            Boolean HasSixPermutedPrimes = false;
            int number = 0,res;
            Char[] numChar;
            String numString, nStr;
            do
            {
                number++;
                numChar = number.ToString().ToArray().OrderBy<Char, Char>(x => x).ToArray();
                numString = new String(numChar);
                HasSixPermutedPrimes = true;
                for (int i = 2; i <= 6; i++)
                {
                    res = number * i;
                    nStr = new String(res.ToString().ToArray().OrderBy<Char, Char>(x => x).ToArray());
                    HasSixPermutedPrimes = HasSixPermutedPrimes && numString == nStr;
                    if (!HasSixPermutedPrimes)
                        break;
                }
            } while (!HasSixPermutedPrimes);
            return number;
        }


        public override string ToString()
        {
            return String.Format("The smallest positive integer, x, such that 2x, 3x, 4x, 5x, and 6x, contain the same digits is {0}.", this.Solve());
        }
    }
}
