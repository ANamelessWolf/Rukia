using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    ///  By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.
    ///         3
    ///        7 4
    ///       2 4 6
    ///      8 5 9 3
    /// That is, 3 + 7 + 4 + 9 = 23.
    /// Find the maximum total from top to bottom of the triangle below:
    ///                                                     75
    ///                                                    95 64
    ///                                                   17 47 82
    ///                                                  18 35 87 10
    ///                                                 20 04 82 47 65
    ///                                                19 01 23 75 03 34
    ///                                               88 02 77 73 07 63 67
    ///                                              99 65 04 28 06 16 70 92
    ///                                             41 41 26 56 83 40 80 70 33
    ///                                            41 48 72 33 47 32 37 16 94 29
    ///                                           53 71 44 65 25 43 91 52 97 51 14
    ///                                          70 11 33 28 77 73 17 78 39 68 17 57
    ///                                         91 71 52 38 17 14 91 43 58 50 27 29 48
    ///                                        63 66 04 68 89 53 67 30 73 16 69 87 40 31
    ///                                       04 62 98 27 23 09 70 98 73 93 38 53 60 04 23
    /// NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route. However, 
    /// Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)
    /// </summary>
    public class MaximumPathSum
    {
        const String PYRAMID =
                            "75@" +
                            "95 64@" +
                            "17 47 82@" +
                            "18 35 87 10@" +
                            "20 04 82 47 65@" +
                            "19 01 23 75 03 34@" +
                            "88 02 77 73 07 63 67@" +
                            "99 65 04 28 06 16 70 92@" +
                            "41 41 26 56 83 40 80 70 33@" +
                            "41 48 72 33 47 32 37 16 94 29@" +
                            "53 71 44 65 25 43 91 52 97 51 14@" +
                            "70 11 33 28 77 73 17 78 39 68 17 57@" +
                            "91 71 52 38 17 14 91 43 58 50 27 29 48@" +
                            "63 66 04 68 89 53 67 30 73 16 69 87 40 31@" +
                            "04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";
        /// <summary>
        /// The sum result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// The pyramid digits
        /// </summary>
        public int[][] Digits;
        /// <summary>
        /// Get maximum total from top to bottom
        /// </summary>
        public MaximumPathSum()
        {
            this.InitDigits();
        }
        /// <summary>
        /// Initialize the pyramid digits
        /// </summary>
        public virtual void InitDigits()
        {
            String[] lines = PYRAMID.Split('@');
            string[] nums;
            this.Digits = new int[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                nums = lines[i].Split(' ');
                this.Digits[i] = new int[nums.Length];
                for (int j = 0; j < nums.Length; j++)
                    this.Digits[i][j] = int.Parse(nums[j]);
            }
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            bool continueFlag = true;
            int[] index = new int[] { 1, 0 };
            long sum = SolveTriangle(ref continueFlag, ref index);
            Console.WriteLine(sum);
            while (continueFlag)
                sum += SolveTriangle(ref continueFlag, ref index);
            return sum;
        }
        /// <summary>
        /// Solve the triangle
        /// </summary>
        /// <param name="continueFlag">True if the sum continues</param>
        /// <param name="index">The start index</param>
        /// <returns>The sum result</returns>
        private long SolveTriangle(ref bool continueFlag, ref int[] index)
        {
            int sumA, sumB, sumC, sumD, maxSum, sum;
            try
            {
                //Console.Clear();
                //Console.WriteLine("\t\t" + this.Digits[index[0] - 1][index[1]]);
                //Console.WriteLine("\t" + this.Digits[index[0]][index[1]] + "\t\t" + this.Digits[index[0]][index[1] + 1]);
                //Console.WriteLine(this.Digits[index[0] + 1][index[1]] + "\t\t" + this.Digits[index[0] + 1][index[1] + 1] + "\t\t" + this.Digits[index[0] + 1][index[1] + 2]);

                sumA = this.Digits[index[0] - 1][index[1]] + this.Digits[index[0]][index[1]] + this.Digits[index[0] + 1][index[1]];
                sumB = this.Digits[index[0] - 1][index[1]] + this.Digits[index[0]][index[1]] + this.Digits[index[0] + 1][index[1] + 1];
                sumC = this.Digits[index[0] - 1][index[1]] + this.Digits[index[0]][index[1] + 1] + this.Digits[index[0] + 1][index[1] + 1];
                sumD = this.Digits[index[0] - 1][index[1]] + this.Digits[index[0]][index[1] + 1] + this.Digits[index[0] + 1][index[1] + 2];

                //Console.WriteLine(this.Digits[index[0] - 1][index[1]] + "+" + this.Digits[index[0]][index[1]] + "+" + this.Digits[index[0] + 1][index[1]] + "=" + sumA);
                //Console.WriteLine(this.Digits[index[0] - 1][index[1]] + "+" + this.Digits[index[0]][index[1]] + "+" + this.Digits[index[0] + 1][index[1] + 1] + "=" + sumB);
                //Console.WriteLine(this.Digits[index[0] - 1][index[1]] + "+" + this.Digits[index[0]][index[1] + 1] + "+" + this.Digits[index[0] + 1][index[1] + 1] + "=" + sumC);
                //Console.WriteLine(this.Digits[index[0] - 1][index[1]] + "+" + this.Digits[index[0]][index[1] + 1] + "+" + this.Digits[index[0] + 1][index[1] + 2] + "=" + sumD);

                maxSum = new int[] { sumA, sumB, sumC, sumD }.Max<int>();
                sum = this.Digits[index[0] - 1][index[1]];
                index[0] += 1;
                if (sumC == maxSum || sumD == maxSum)
                    index[1] += 1;
                return sum;
            }
            catch (Exception)
            {
                continueFlag = false;
                sumA = this.Digits[index[0] - 1][index[1]] + this.Digits[index[0]][index[1]];
                sumB = this.Digits[index[0] - 1][index[1]] + this.Digits[index[0]][index[1] + 1];
                if (sumA > sumB)
                    return sumA;
                else
                    return sumB;
            }

        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The maximum total from top to bottom of the triangle below is {0}", this.Result);
        }


    }
}
