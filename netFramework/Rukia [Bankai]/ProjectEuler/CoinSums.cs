using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:
    /// 1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
    /// It is possible to make £2 in the following way:
    /// 1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
    /// How many different ways can £2 be made using any number of coins?
    /// </summary>
    public class CoinSums
    {
        const int MAX_COIN_L1 = 2;
        const int MAX_COIN_50P = 4;
        const int MAX_COIN_20P = 10;
        const int MAX_COIN_10P = 20;
        const int MAX_COIN_5P = 40;
        const int MAX_COIN_2P = 100;
        const int MAX_COIN_1P = 200;
        /// <summary>
        /// The coin list combination
        /// </summary>
        public List<String> CoinSumList;
        /// <summary>
        /// The result
        /// </summary>
        public int Result { get { return Solve(); } }
        /// <summary>
        /// Find all the sums that are equal to a total
        /// </summary>
        /// <param name="total">The total value</param>
        public CoinSums()
        {
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private int Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int sum = 0;
            CoinSumList = new List<string>();
            this.CoinSumList.Add("£2(1)");
            AddCombination(MAX_COIN_L1, 0, 0, 0, 0, 0, 0);
            AddCombination(0, MAX_COIN_50P, 0, 0, 0, 0, 0);
            AddCombination(0, 0, MAX_COIN_20P, 0, 0, 0, 0);
            AddCombination(0, 0, 0, MAX_COIN_10P, 0, 0, 0);
            AddCombination(0, 0, 0, 0, MAX_COIN_5P, 0, 0);
            AddCombination(0, 0, 0, 0, 0, MAX_COIN_2P, 0);
            AddCombination(0, 0, 0, 0, 0, 0, MAX_COIN_1P);
            for (int a = 0; a < MAX_COIN_L1; a++)
                for (int b = 0; b < MAX_COIN_50P-a; b++)
                    for (int c = 0; c < MAX_COIN_20P-b; c++)
                        for (int d = 0; d < MAX_COIN_10P-c; d++)
                            for (int e = 0; e < MAX_COIN_5P-d; e++)
                                for (int f = 0; f < MAX_COIN_2P-e; f++)
                                    for (int g = 0; g < MAX_COIN_1P-f; g++)
                                    {
                                        sum = a * 100 + b * 50 + c * 20 + d * 10 + e * 5 + f * 2 + g;
                                        if (sum == 200)
                                            AddCombination(a, b, c, d, e, f, g);
                                    }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            this.CoinSumList.Sort();
            return this.CoinSumList.Count;
        }
        /// <summary>
        /// Adds a combinations
        /// </summary>
        /// <param name="a">The number of coins of type £1</param>
        /// <param name="b">The number of coins of type 50p</param>
        /// <param name="c">The number of coins of type 20p</param>
        /// <param name="d">The number of coins of type 10p</param>
        /// <param name="e">The number of coins of type 5p</param>
        /// <param name="f">The number of coins of type 2p</param>
        /// <param name="f">The number of coins of type 1p</param>
        private void AddCombination(int a, int b, int c, int d, int e, int f, int g)
        {
            StringBuilder sb = new StringBuilder();
            if (a != 0)
                sb.Append(String.Format("£1({0}) + ", a));
            if (b != 0)
                sb.Append(String.Format("50p({0}) + ", b));
            if (c != 0)
                sb.Append(String.Format("20p({0}) + ", c));
            if (d != 0)
                sb.Append(String.Format("10p({0}) + ", d));
            if (e != 0)
                sb.Append(String.Format("5p({0}) + ", e));
            if (f != 0)
                sb.Append(String.Format("2p({0}) + ", f));
            if (g != 0)
                sb.Append(String.Format("1p({0}) + ", g));
            this.CoinSumList.Add(sb.ToString().Substring(0, sb.ToString().Length - 3));
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("There are {0} different ways to made £2 using any number of coins", this.Result);
        }
    }
}

