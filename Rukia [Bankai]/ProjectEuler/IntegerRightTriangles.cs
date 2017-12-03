using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.
    /// {20,48,52}, {24,45,51}, {30,40,50}
    /// For which value of p ≤ 1000, is the number of solutions maximised?
    /// </summary>
    public class IntegerRightTriangles : ISolution<int>
    {
        public int Limit;
        public int Perimeter;
        public Dictionary<int, List<string>> Solution;
        public IntegerRightTriangles(int limit = 1000)
        {
            this.Limit = limit;
        }

        public int Result
        {
            get { return Solve(); }
        }

        public int Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            this.Solution = new Dictionary<int, List<string>>();
            int[] order;
            String item;
            int c, p = 0, maxCount = 0;
            double h;
            for (int a = 1; a <= this.Limit; a++)
                for (int b = a; b <= this.Limit; b++)
                {
                    h = Math.Sqrt(a * a + b * b);
                    if (h.ToString().Split('.').Length != 2)
                    {
                        c = (int)h;
                        p = a + b + c;
                        if (p <= this.Limit)
                        {
                            if (!this.Solution.ContainsKey(p))
                                this.Solution.Add(p, new List<string>());
                            order = new int[] { a, b, c }.OrderBy<int, int>(X => X).ToArray();
                            item = "{" + String.Format("{0},{1},{2}", order[0], order[1], order[2]) + "}";
                            if (!Solution[p].Contains(item))
                                Solution[p].Add(item);
                        }
                    }
                }
            foreach (int perimeter in this.Solution.Keys)
            {
                if (this.Solution[perimeter].Count > maxCount)
                {
                    maxCount = this.Solution[perimeter].Count;
                    this.Perimeter = perimeter;
                }
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            StringBuilder sb = new StringBuilder();

            foreach (String solution in this.Solution[this.Perimeter])
                sb.Append(solution + ", ");
            Console.WriteLine(sb.ToString().Substring(0, sb.ToString().Length - 2));
            return this.Solution[this.Perimeter].Count;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            String r = this.Result.ToString(),
                s = String.Format("For a value of p ={0} has a maximum number of solutions from p<=1000, has a total number of solutions of {1}", this.Perimeter, r);
            return s;
        }
    }
}
