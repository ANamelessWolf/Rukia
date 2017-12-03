using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// The arithmetic sequence, 1487, 4817, 8147, in which each of the terms increases by 3330, is unusual in two ways: 
    /// (i) each of the three terms are prime, and, 
    /// (ii) each of the 4-digit numbers are permutations of one another.
    /// There are no arithmetic sequences made up of three 1-, 2-, or 3-digit primes, exhibiting this property, but there is one other 4-digit increasing sequence.
    /// What 12-digit number do you form by concatenating the three terms in this sequence?
    /// </summary>
    public class PrimePermutations : ISolution<int[]>
    {
        const String PRIME_PATH = @"..\..\Assets\Primes\";
        const String PRIME_FILE = "50000000.txt";
        PrimeFileReader pReader;
        List<long[]> PrimePermutation;
        /// <summary>
        /// Creates a new problem
        /// </summary>
        public PrimePermutations()
        {
            Console.WriteLine("Calculando Permutaciones...");
            pReader = new PrimeFileReader(new FileInfo(Path.Combine(PRIME_PATH, PRIME_FILE)), new long[] { 999, 10000 });
            Stopwatch sw = new Stopwatch();
            sw.Start();
            FindPrimePermutations();
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
        }
        /// <summary>
        /// Find the permutation numbers
        /// </summary>
        private void FindPrimePermutations()
        {
            long[] primes = pReader.SmallerThan(10000);
            PrimePermutation = new List<long[]>();
            IEnumerable<long> primePer;
            long[] nums;
            Permutation p;
            for (int i = 0; i < primes.Length; i++)
            {
                p = new Permutation(primes[i].ToString());
                primePer = p.Permutations.Select<String, long>(x => long.Parse(x)).Where(x => primes.Contains(x)).Distinct();
                if (primePer.Count() >= 3)
                {
                    nums = new long[primePer.Count()];
                    for (int j = 0; j < primePer.Count(); j++)
                        nums[j] = primePer.ElementAt(j);
                    nums = nums.OrderBy<long, long>(x => x).ToArray();
                    PrimePermutation.Add(nums);
                }
            }
        }

        public int[] Result
        {
            get { return Solve(); }
        }

        public int[] Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<int[]> res = new List<int[]>();
            long vector;
            int count = 0;
            List<int> validNums = new List<int>();
            foreach (long[] nums in this.PrimePermutation.OrderBy<long[], long>(x => x[0]))
                for (int z = 1; z < nums.Length; z++)
                    for (int y = z + 1; y < nums.Length; y++)
                    {
                        vector = nums[y] - nums[z];
                        for (int w = 0; w < nums.Length; w++)
                        {
                            count = 0;
                            validNums = new List<int>();
                            while (count < 3)
                            {
                                if (nums.Contains(nums[w] + vector * count))
                                    validNums.Add((int)(nums[w] + vector * count));
                                count++;
                            }
                            int[] vNum = validNums.ToArray();
                            if (validNums.Count == 3 && !Contains(vNum, res))
                                res.Add(vNum);
                        }
                    }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return res[res.Count - 1];
        }

        public Boolean Contains(int[] val, List<int[]> array)
        {
            foreach (int[] num in array)
                if (num[0] == val[0] && num[1] == val[1] && num[2] == val[2])
                    return true;
            return false;
        }

        public override string ToString()
        {
            int[] num = this.Solve();
            return String.Format("The 12-digit number do you form by concatenating the three terms in this sequence is {0}{1}{2}", num[0], num[1], num[2]);
        }
    }
}
