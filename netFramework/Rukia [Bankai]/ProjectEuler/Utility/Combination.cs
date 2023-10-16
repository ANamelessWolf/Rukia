using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class Combination
    {
        Double N, R;



        public void Set(Double n, Double r)
        {
            this.N = n;
            this.R = r;
        }

        public Combination(Double n, Double r)
        {
            this.Set(n, r);
        }

        public Double Calc()
        {
            return Factorial(this.N) / (this.Factorial(this.R) * this.Factorial(this.N - this.R));
        }

        public Double Factorial(Double num)
        {
            Double res = 1d;
            if (num > 0)
                for (Double i = 1d; i <= num; i++)
                    res *= i;
            return res;

        }

    }
}
