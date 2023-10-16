using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// The series, 1^1 + 2^2 + 3^3 + ... + 10^10 = 10405071317.
    /// Find the last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000.
    /// </summary>
    public class SelfPowers : ISolution<long>
    {



        public long Result
        {
            get { return Solve(); }
        }

        public long Solve()
        {
            BigNumber num = BigOperation.Pow(1, 1), res;
            for (int i = 2; i <= 1000; i++)
            {
                res = BigOperation.Pow(i, i);
                num += res;
            }
            Console.WriteLine(num);
            return long.Parse(num.ToString().Substring(num.ToString().Length - 10));
        }
        public override string ToString()
        {
            return String.Format("The last ten digits of the series, 1^1 + 2^2 + 3^3 + ... + 1000^1000 is {0}", this.Result);
        }
    }
}
