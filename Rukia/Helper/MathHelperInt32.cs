using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Helper
{
    public class MathHelperInt32 : IMath<int>
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

        int LongRandom(int min, int max, Random rand)
        {
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)min, (Int32)max);
            return (int)result;
        }

        public int NextRandom(int minValue, int maxValue)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return LongRandom(minValue, maxValue, rand);
        }

        public int Mod(int number, int div)
            => number % div;

        public int ModPow(int value, int exponent, int modulus)
        {
            int result = 1;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1) result = result * value % modulus;
                value = value * value % modulus;
                exponent >>= 1;
            }
            return (int)result;
        }
    }
}
