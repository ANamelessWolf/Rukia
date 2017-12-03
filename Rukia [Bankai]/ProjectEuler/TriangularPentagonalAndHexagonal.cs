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
    /// Triangle, pentagonal, and hexagonal numbers are generated by the following formulae:
    /// Triangle 	  	Tn=n(n+1)/2 	  	1, 3, 6, 10, 15, ...
    /// Pentagonal 	  	Pn=n(3n−1)/2 	  	1, 5, 12, 22, 35, ...
    /// Hexagonal 	  	Hn=n(2n−1) 	  	1, 6, 15, 28, 45, ...
    /// It can be verified that T285 = P165 = H143 = 40755.
    /// Find the next triangle number that is also pentagonal and hexagonal.
    /// </summary>
    public class TriangularPentagonalAndHexagonal : ISolution<long>
    {
        const int START_TRIANGLE_INDEX = 285;

        /// <summary>
        /// Return the solution
        /// </summary>
        public long Result
        {
            get { return this.Solve(); }
        }
        /// <summary>
        /// Solves the problem
        /// </summary>
        /// <returns>The problem solution</returns>
        public long Solve()
        {
            Boolean IsValid = false;
            long count = START_TRIANGLE_INDEX;
            long number;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                count++;
                number = TriangleNumberGenerator.Get(count);
                IsValid = PentagonNumbers.IsPentagonalNumber(number) && IsHexagonalNumber(number);
            } while (!IsValid);
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return number;
        }
        /// <summary>
        /// Check if the number is hexagonal
        /// </summary>
        /// <param name="n">The number is Hexagonal number</param>
        /// <returns>The hexagonal number</returns>
        public static bool IsHexagonalNumber(long n)
        {
            double d = (Math.Sqrt(1 + 8 * n) + 1.0) / 4.0;
            return d % 1 == 0d;
        }

        public override string ToString()
        {
            return String.Format("The next triangle number that is also pentagonal and hexagonal {0}", this.Result);
        }

    }
}
