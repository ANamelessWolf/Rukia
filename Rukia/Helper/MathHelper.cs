﻿using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Helper
{
    public class MathHelper : IMath<ulong>
    {
        public ulong SquareRoot(ulong number)
        {
            var n = Math.Sqrt(number);
            return (ulong)Math.Truncate(n);
        }

        public ulong Power(ulong number, int power)
        {
            if (power == 0) return 1;
            ulong res = number;
            for (int i = 1; i < power; i++)
                res *= number;
            return res;
        }

        ulong LongRandom(ulong min, ulong max, Random rand)
        {
            long result = rand.Next((Int32)(min >> 32), (Int32)(max >> 32));
            result = (result << 32);
            result = result | (long)rand.Next((Int32)min, (Int32)max);
            return (ulong)result;
        }

        public ulong NextRandom(ulong minValue, ulong maxValue)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return LongRandom(minValue, maxValue, rand);
        }

        public ulong Mod(ulong number, ulong div)
            => number % div;

        public ulong ModPow(ulong value, ulong exponent, ulong modulus)
        {
            ulong result = 1;
            while (exponent > 0)
            {
                if ((exponent & 1) == 1) result = result * value % modulus;
                value = value * value % modulus;
                exponent >>= 1;
            }
            return (ulong)result;
        }
    }
}
