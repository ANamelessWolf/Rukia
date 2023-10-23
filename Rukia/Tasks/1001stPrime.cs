using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    public class ThousandFirstPrime : ISolution
    {
        public int Number { get;  }
        public int Result { get; set; }

        public ThousandFirstPrime(int nst)
        {
            this.Number = nst;
            this.Result = Solve();
        }

        public string PrintResult()
        {
            return String.Format("The {0}st prime number is {1}", this.Number, this.Result);
        }

        public int Solve()
        {
            if (this.Number == 1)
                return 2;

            int index=2, num = 3, lastPrime=3;
            PrimeTester pTester = new PrimeTester();
            while (index < this.Number) { 
                num+=2;
                if (pTester.IsPrime(num))
                {
                    index++;
                    lastPrime = num;
                }
            }
            return lastPrime;
        }
    }
}
