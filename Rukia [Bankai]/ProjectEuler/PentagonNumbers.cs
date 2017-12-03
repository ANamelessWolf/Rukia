﻿using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// Pentagonal numbers are generated by the formula, Pn=n(3n−1)/2. The first ten pentagonal numbers are:
    /// 1, 5, 12, 22, 35, 51, 70, 92, 117, 145, ...
    /// It can be seen that P4 + P7 = 22 + 70 = 92 = P8. However, their difference, 70 − 22 = 48, is not pentagonal.
    /// Find the pair of pentagonal numbers, Pj and Pk, 
    /// for which their sum and difference are pentagonal and D = |Pk − Pj| is minimised; what is the value of D?
    /// </summary>
    public class PentagonNumbers : ISolution<long>
    {
        long pj, pk, d;
        List<long> Numbers;
        long[] PNumberMin;

        public PentagonNumbers()
        {
            this.Solve();
        }

        public long Result
        {
            get { return this.Solve(); }
        }

        public long Solve()
        {
            Numbers = new List<long>();
            long count = 1, dif, sum;
            d = long.MaxValue;
            PNumberMin = null;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                Numbers.Add(PentagonalNumber(count));
                for (int j = 0; j < Numbers.Count - 1; j++)
                {
                    dif = this.Numbers[this.Numbers.Count - 1] - this.Numbers[j];
                    if (IsPentagonalNumber(dif))
                    {
                        sum = this.Numbers[this.Numbers.Count - 1] + this.Numbers[j];
                        if (IsPentagonalNumber(sum))
                        {
                            PNumberMin = new long[] { this.Numbers.Count, j + 1, dif };
                            break;
                        }
                    }
                }
                count++;
            } while (PNumberMin == null);
            pk = this.PNumberMin[0];
            pj = this.PNumberMin[1];
            d = this.PNumberMin[2];
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return d;
        }

        public long PentagonalNumber(long n)
        {
            return n * (3 * n - 1) / 2;
        }

        public static Boolean IsPentagonalNumber(long n)
        {
            double d = (Math.Sqrt(1 + 24 * n) + 1.0) / 6.0;
            return d % 1 == 0d;

        }


        public override string ToString()
        {
            return String.Format("The pair of pentagonal numbers, Pj: {0} and Pk: {1} which had sum and difference pentagonal D Has value of D: {2}", pj, pk, d);
        }




    }
}
