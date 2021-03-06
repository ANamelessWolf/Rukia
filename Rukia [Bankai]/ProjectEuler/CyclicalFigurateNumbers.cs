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
    /// Triangle, square, pentagonal, hexagonal, heptagonal, and octagonal numbers are all figurate (polygonal) numbers and are generated by the following formulae:
    /// Triangle 	  	P3,n=n(n+1)/2 	  	1, 3, 6, 10, 15, ...
    /// Square 	  	P4,n=n2 	  	1, 4, 9, 16, 25, ...
    /// Pentagonal 	  	P5,n=n(3n−1)/2 	  	1, 5, 12, 22, 35, ...
    /// Hexagonal 	  	P6,n=n(2n−1) 	  	1, 6, 15, 28, 45, ...
    /// Heptagonal 	  	P7,n=n(5n−3)/2 	  	1, 7, 18, 34, 55, ...
    /// Octagonal 	  	P8,n=n(3n−2) 	  	1, 8, 21, 40, 65, ...
    /// The ordered set of three 4-digit numbers: 8128, 2882, 8281, has three interesting properties.
    /// The set is cyclic, in that the last two digits of each number is the first two digits of the next number (including the last number with the first).
    /// Each polygonal type: triangle (P3,127=8128), square (P4,91=8281), and pentagonal (P5,44=2882), is represented by a different number in the set.
    /// This is the only set of 4-digit numbers with this property.
    /// Find the sum of the only ordered set of six cyclic 4-digit numbers 
    /// for which each polygonal type: triangle, square, pentagonal, hexagonal, heptagonal, and octagonal, is represented by a different number in the set.
    /// </summary>
    public class CyclicalFigurateNumbers : ISolution<int>
    {
        public int Result
        {
            get { return this.Solve(); }
        }

        public int Solve()
        {
            int[] nums = new int[6];
            CycleNumbers = new List<int[]>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //Obtener los números ciclicos.
            for (int i = 0; i < validFourDigits.Count; i++)
                ValidateCycle(this.validFourDigits, this.validFourDigits[i]);
            CycleNumbers = FilterCycleNumbers(CycleNumbers);
            nums = CycleNumbers.FirstOrDefault();
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return nums.Sum();
        }

        private List<int[]> FilterCycleNumbers(List<int[]> CycleNumbers)
        {
            List<int[]> valid = new List<int[]>();

            foreach (int[] nums in CycleNumbers)
            {
                if (IsPolygonNumber(nums))
                    valid.Add(nums);
            }
            return valid;
        }

        private bool IsPolygonNumber(int[] nums)
        {
            int tri, sqr, pen, hex, hep, oct;
            tri = 0;
            sqr = 0;
            pen = 0;
            hex = 0;
            hep = 0;
            oct = 0;
            foreach (int num in nums)
            {
                if (TriangleNums.Contains(num))
                    tri++;
                if (SquareNums.Contains(num))
                    sqr++;
                if (PentagonalNums.Contains(num))
                    pen++;
                if (HexagonalNums.Contains(num))
                    hex++;
                if (HeptagonalNums.Contains(num))
                    hep++;
                if (OctagonalNums.Contains(num))
                    oct++;
            }
            return tri > 1 && sqr > 0 && pen > 0 && hex > 0 && hep > 0 && oct > 0;
        }

        private void ValidateCycle(List<int> validNums, int num)
        {
            int[] nums = new int[6];
            ValidateCycle(validNums, num, 0, ref nums);

        }

        private void ValidateCycle(List<int> validNums, int num, int depth, ref int[] nums)
        {

            if (depth == 6 || (depth > 0 && nums[depth - 1] == num))
            {
                if (nums[0] == num && AreValid(nums))
                    CycleNumbers.Add(new int[] { nums[0], nums[1], nums[2], nums[3], nums[4], nums[5] });
                return;
            }
            nums[depth] = num;
            String dig = num.ToString().Substring(2, 2);
            int[] nMem = validNums.Where(x => x.ToString().Substring(0, 2) == dig).ToArray();
            if (nMem.Length > 0)
                foreach (int n in nMem)
                    ValidateCycle(validNums, n, depth + 1, ref nums);
        }

        private bool AreValid(int[] nums)
        {
            List<int> numInOrder = nums.OrderBy<int, int>(x => x).ToList();
            Boolean lessThan0 = true, existFlag = false, noRepeat = false;
            numInOrder.ForEach(x => lessThan0 = lessThan0 && x > 0);
            if (lessThan0)
            {
                Dictionary<int, int> nCount = new Dictionary<int, int>();
                foreach (int key in numInOrder)
                    if (nCount.ContainsKey(key))
                        nCount[key]++;
                    else
                        nCount.Add(key, 1);
                noRepeat = nCount.Values.Count == 6;
                if (noRepeat)
                {
                    foreach (int[] cNums in this.CycleNumbers)
                    {
                        int[] cNumsInOrder = cNums.OrderBy<int, int>(x => x).ToArray();
                        existFlag = cNumsInOrder[0] == numInOrder[0] &&
                            cNumsInOrder[1] == numInOrder[1] &&
                            cNumsInOrder[2] == numInOrder[2] &&
                            cNumsInOrder[3] == numInOrder[3] &&
                            cNumsInOrder[4] == numInOrder[4] &&
                            cNumsInOrder[5] == numInOrder[5];
                        if (existFlag)
                            break;
                    }
                }
            }
            return lessThan0 && !existFlag && noRepeat;
        }


        List<int> TriangleNums, SquareNums, PentagonalNums, HexagonalNums, HeptagonalNums, OctagonalNums, validFourDigits;
        List<int[]> CycleNumbers;

        public CyclicalFigurateNumbers()
        {
            TriangleNums = new List<int>();
            SquareNums = new List<int>();
            PentagonalNums = new List<int>();
            HexagonalNums = new List<int>();
            HeptagonalNums = new List<int>();
            OctagonalNums = new List<int>();
            OctagonalNums = new List<int>();
            validFourDigits = new List<int>();
            const int LIMIT = 10000;
            int n = 1, triNum = 0, sqrNum = 0, penNum = 0, hexNum = 0, hepNum = 0, octNum = 0;
            do
            {
                triNum = n * (n + 1) / 2;
                sqrNum = n * n;
                penNum = n * (3 * n - 1) / 2;
                hexNum = n * (2 * n - 1);
                hepNum = n * (5 * n - 3) / 2;
                octNum = n * (3 * n - 2);
                if (triNum > 999 && triNum < LIMIT)
                    TriangleNums.Add(triNum);
                if (sqrNum > 999 && sqrNum < LIMIT)
                    SquareNums.Add(sqrNum);
                if (penNum > 999 && penNum < LIMIT)
                    PentagonalNums.Add(penNum);
                if (hexNum > 999 && hexNum < LIMIT)
                    HexagonalNums.Add(hexNum);
                if (hepNum > 999 && hepNum < LIMIT)
                    HeptagonalNums.Add(hepNum);
                if (octNum > 999 && octNum < LIMIT)
                    OctagonalNums.Add(octNum);
                n++;
            } while (triNum < LIMIT || sqrNum < LIMIT || penNum < LIMIT || hexNum < LIMIT || hepNum < LIMIT || octNum < LIMIT);
            validFourDigits = TriangleNums.Union(SquareNums).Union(PentagonalNums).Union(HexagonalNums).Union(HeptagonalNums).Union(OctagonalNums).Distinct().OrderBy(x => x).ToList();
        }

        public override string ToString()
        {
            return String.Format("The sum of the only ordered set of six cyclic 4-digit numbers for which each polygonal type: triangle, square, pentagonal, hexagonal, heptagonal, and octagonal, is represented by a different number in the set is {0}.", this.Solve());
        }

    }
}
