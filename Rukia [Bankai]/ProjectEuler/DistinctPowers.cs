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
    /// Consider all integer combinations of ab for 2 ≤ a ≤ 5 and 2 ≤ b ≤ 5:
    /// 2^2=4, 2^3=8, 2^4=16, 2^5=32
    /// 3^2=9, 3^3=27, 3^4=81, 3^5=243
    /// 4^2=16, 4^3=64, 4^4=256, 4^5=1024
    /// 5^2=25, 5^3=125, 5^4=625, 5^5=3125
    /// If they are then placed in numerical order, with any repeats removed, we get the following sequence of 15 distinct terms:
    /// 4, 8, 9, 16, 25, 27, 32, 64, 81, 125, 243, 256, 625, 1024, 3125
    /// How many distinct terms are in the sequence generated by ab for 2 ≤ a ≤ 100 and 2 ≤ b ≤ 100?
    /// </summary>
    public class DistinctPowers
    {
        /// <summary>
        /// The Distinct power members
        /// </summary>
        public List<String> Members;
        /// <summary>
        /// The number Limit
        /// </summary>
        public int Limit;
        /// <summary>
        /// The result
        /// </summary>
        public int Result { get { return Solve(); } }
        /// <summary>
        /// Get the sum of all spiral members
        /// </summary>
        /// <param name="limit">The matrix spiral order</param>
        public DistinctPowers(int limit = 100)
        {
            this.Limit = limit;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private int Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BigNumber num;
            Members = new List<string>();
            for (int a = 2; a <= this.Limit; a++)
                for (int b = 2; b <= this.Limit; b++)
                {
                    num = BigOperation.Pow(a, b);
                    if (!Members.Contains(num.ToString()))
                        Members.Add(num.ToString());
                }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return this.Members.Count;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            String res = String.Format("The number of terms that are in the sequence generated by ab for 2 ≤ a ≤ {0} and 2 ≤ b ≤ {0} is {1}", this.Limit, this.Result);
            //StringBuilder sb = new StringBuilder();
            //this.Members.Sort((x, y) =>
            //{
            //    int ix, iy;
            //    return int.TryParse(x, out ix) && int.TryParse(y, out iy)
            //          ? ix.CompareTo(iy) : string.Compare(x, y);
            //});
            //foreach (String m in this.Members)
            //    sb.Append(m + ", ");
            //String members = sb.ToString().Substring(0, sb.ToString().Length - 2);
            return res;// members + '\n' + res;
        }
    }
}
