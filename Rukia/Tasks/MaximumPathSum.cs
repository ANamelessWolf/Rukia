using Nameless.Libraries.Rukia.ProjectEuler.Data;
using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
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
    public class MaximumPathSum : ISolution
    {
        const String TINY_PYRAMID =
                            "3@" +
                            "7 4@" +
                            "2 4 6@" +
                            "8 5 9 3";

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

        public IntBinaryNode Tree { get; }

        public IntBinaryNode[] Leaves { get; set; }

        public int Total { get; }

        public MaximumPathSum(PyramidSize size)
        {
            var pyramid = this.GetPyramid(size);
            this.Tree = InitTree(pyramid);
            this.Total = this.Solve();
        }

        public int Solve()
        {
            int maxSum = 0;
            foreach (var node in this.Leaves)
            {
                if (node.Total > maxSum)
                    maxSum = node.Total;
            }
            return maxSum;
        }

        public string PrintResult()
        {
            return String.Format("The maximum total from top to bottom of the triangle below is {0}", this.Total);
        }


        private string GetPyramid(PyramidSize size)
        {
            switch (size)
            {
                case PyramidSize.Tiny:
                    return TINY_PYRAMID;
                case PyramidSize.Normal:
                    return PYRAMID;
                case PyramidSize.Huge:
                    return "";
                default:
                    return "";
            }
        }

        private IntBinaryNode InitTree(string data)
        {
            string[] lines = data.Split('@');
            IntBinaryNode root = null;
            IntBinaryNode[] current = null, next = new IntBinaryNode[0];
            for (int i = 1; i < lines.Length; i++)
            {
                if (current == null)
                    current = GetValues(lines[i - 1]);
                else
                    current = next;
                next = GetValues(lines[i]);

                if (current.Length == 1)
                    root = current[0];

                for (int j = 0; j < current.Length; j++)
                {
                    current[j].Left = next[j];
                    next[j].AddParent(current[j]);
                    current[j].Right = next[j + 1];
                    next[j + 1].AddParent(current[j]);
                }
            }
            this.Leaves = next;
            return root;
        }

        private IntBinaryNode[] GetValues(string line)
        {
            string[] numbers = line.Split(' ');
            IntBinaryNode[] nodes = new IntBinaryNode[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                var value = int.Parse(numbers[i]);
                nodes[i] = new IntBinaryNode(value);
            }
            return nodes;
        }


    }
}

public enum PyramidSize
{
    Tiny = 1,
    Normal = 2,
    Huge = 3
}