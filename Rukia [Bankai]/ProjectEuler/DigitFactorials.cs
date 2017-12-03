using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// 145 is a curious number, as 1! + 4! + 5! = 1 + 24 + 120 = 145.
    /// Find the sum of all numbers which are equal to the sum of the factorial of their digits.
    /// Note: as 1! = 1 and 2! = 2 are not sums they are not included.
    /// </summary>
    public class DigitFactorials : ISolution<long>
    {
        public List<long> CuriosNumbers;


        public Dictionary<char, long> Factorials;

        public DigitFactorials()
        {
            this.Factorials = new Dictionary<char, long>();
            this.Factorials.Add('0', 1);
            long factorial = 1;
            for (int i = 1; i <= 9; i++)
            {
                factorial *= i;
                this.Factorials.Add(i.ToString()[0], factorial);
            }

        }

        public long Result
        {
            get { return Solve(); }
        }

        public long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            CuriosNumbers = new List<long>();
            long limit = this.Factorials['9'];
            long currentNum = 3;
            long sum;
            while (currentNum <= limit)
            {
                sum = 0;
                foreach (char ch in currentNum.ToString().ToCharArray())
                {
                    sum += Factorials[ch];
                    if (sum > currentNum)
                        break;
                }
                if (sum == currentNum)
                    this.CuriosNumbers.Add(currentNum);
                currentNum++;
            }
            sum = CuriosNumbers.Sum();
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return sum;
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The sum of all numbers which are equal to the sum of the factorial of their digits is {0}", this.Result);
        }

    }
}
