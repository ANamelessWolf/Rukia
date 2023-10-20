using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Helper
{
    public class MathHelper : IMath<int>
    {
        public int SquareRoot(int number)
        {
            var n = Math.Sqrt(number);
            return (int)Math.Truncate(n);
        }

        public int Power(int number, int power)
        {
            if (power == 0) return 1;
            int res = number;
            for (int i = 1; i < power; i++)
                res *= number;
            return res;
        }

        public int NextRandom(int minValue, int maxValue)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(minValue, maxValue);
        }

        

    }
}
