using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    /// The following iterative sequence is defined for the set of positive integers:
    /// n → n/2 (n is even)
    /// n → 3n + 1 (n is odd)
    /// Using the rule above and starting with 13, we generate the following sequence:
    /// 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
    /// It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
    /// Which starting number, under one million, produces the longest chain?
    /// NOTE: Once the chain starts the terms are allowed to go above one million.
    /// </summary>
    public class LongestCollatzSequence : ISolution
    {
        /// <summary>
        /// The limit
        /// </summary>
        public int Limit;

        public int Result;

        private HashSet<long> Members { get; set; }

        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="limit">The number to extract it prime factor</param>
        public LongestCollatzSequence(int limit)
        {
            this.Limit = limit;
            this.Result = this.Solve();
            this.Members = new HashSet<long>();
        }

        public string PrintResult()
        {
            return String.Format("The starting number {0}, produces the longest chain number under one million", this.Result);
        }

        public int Solve()
        {
            int longestSeq = 0;
            int sNum = 2;
            this.Members = new HashSet<long>();
            for (int test = 2; test < this.Limit; test++)
            {
                if (!Members.Contains(test))
                {
                    var times = this.CountCollatz((long)test);
                    if (longestSeq < times)
                    {
                        longestSeq = times;
                        sNum = test;
                    }
                }
            }
            return sNum;
        }

        private int CountCollatz(long test)
        {
            int times = 1;
            while (test > 1)
            {
                test = test.NextCollatzSequence();
                if (test < this.Limit && !Members.Contains(test))
                    this.Members.Add(test);
                times++;
            }
            return times;
        }

        private string PrintSequence(long test)
        {
            string seq = $"{test}";
            int times = 1;
            while (test > 1)
            {
                test = test.NextCollatzSequence();
                seq += $", {test}";
                times++;
            }
            return $"Members: {times} [{seq}]";
        }
    }
}
