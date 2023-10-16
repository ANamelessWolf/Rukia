using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    public class SpiralPrimes : ISolution<long>
    {
        public long Result
        {
            get { return this.Solve(); }
        }

        public long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SpiralPrimeMatrix spMatrix = new SpiralPrimeMatrix();
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return spMatrix.Order;
        }



        public override string ToString()
        {
            return String.Format("The side length of the square spiral for which the ratio of primes along both diagonals first falls below 10% is {0}", this.Result);
        }


    }
}
