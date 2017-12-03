using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// In the 20×20 grid below, four numbers along a diagonal.
    /// The product of these numbers is 26 × 63 × 78 × 14 = 1788696.
    /// What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
    /// </summary>
    public class LargestProductOnAGrid
    {
        const String GRID =
                    "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08@" +
                    "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00@" +
                    "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65@" +
                    "52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91@" +
                    "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80@" +
                    "24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50@" +
                    "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70@" +
                    "67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21@" +
                    "24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72@" +
                    "21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95@" +
                    "78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92@" +
                    "16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57@" +
                    "86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58@" +
                    "19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40@" +
                    "04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66@" +
                    "88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69@" +
                    "04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36@" +
                    "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16@" +
                    "20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54@" +
                    "01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";
        public int MultiplicationSize;
        /// <summary>
        /// The grid as a list of integers
        /// </summary>
        public int[,] Grid;
        /// <summary>
        /// The product result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// The size of multiplication
        /// </summary>
        /// <param name="size">The multiplication size</param>
        public LargestProductOnAGrid(int size = 4)
        {
            InitGrid();
            this.MultiplicationSize = size;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            int[] pivot = new int[2];
            long result = 0;
            for (int i = 0; i < this.Grid.GetUpperBound(0); i++)
                for (int j = 0; j < this.Grid.GetUpperBound(1); j++)
                {
                    pivot[0] = j;
                    pivot[1] = i;
                    ValidateResult(ref result, GridMultiplication(ref pivot, GridMultiplicationType.Right, this.MultiplicationSize));
                    ValidateResult(ref result, GridMultiplication(ref pivot, GridMultiplicationType.Down, this.MultiplicationSize));
                    ValidateResult(ref result, GridMultiplication(ref pivot, GridMultiplicationType.LeftBottomDiagonal, this.MultiplicationSize));
                    ValidateResult(ref result, GridMultiplication(ref pivot, GridMultiplicationType.RightBottomDiagonal, this.MultiplicationSize));
                }
            return result;
        }
        /// <summary>
        /// Validates the multiplication result
        /// </summary>
        /// <param name="result">The multiplication result to validate</param>
        /// <param name="value">The multiplication value</param>
        private void ValidateResult(ref long result, long value)
        {
            if (value > result)
                result = value;
        }
        /// <summary>
        /// Solve the multiplication
        /// </summary>
        /// <param name="pivot">The pivot diagonal</param>
        /// <param name="tp">The type of diagonal</param>
        /// <param name="multSize">The size of the product</param>
        /// <returns>The multiplication product</returns>
        private long GridMultiplication(ref int[] pivot, GridMultiplicationType tp, int multSize)
        {
            int x = pivot[0],
                y = pivot[1];
            long res = this.Grid[pivot[0], pivot[1]];
            for (int i = 0; i < multSize - 1; i++)
            {
                try
                {
                    UpdatePivot(ref pivot, tp);
                }
                catch (Exception)
                {
                    pivot[0] = x;
                    pivot[1] = y;
                    return 0;
                }
                res *= this.Grid[pivot[0], pivot[1]];
            }
            pivot[0] = x;
            pivot[1] = y;
            return res;
        }

        private void UpdatePivot(ref int[] pivot, GridMultiplicationType tp)
        {
            switch (tp)
            {
                case GridMultiplicationType.LeftBottomDiagonal:
                    UpdatePivot(ref pivot, GridMultiplicationType.Left);
                    UpdatePivot(ref pivot, GridMultiplicationType.Down);
                    break;
                case GridMultiplicationType.LeftUpDiagonal:
                    UpdatePivot(ref pivot, GridMultiplicationType.Left);
                    UpdatePivot(ref pivot, GridMultiplicationType.Up);
                    break;
                case GridMultiplicationType.RightBottomDiagonal:
                    UpdatePivot(ref pivot, GridMultiplicationType.Right);
                    UpdatePivot(ref pivot, GridMultiplicationType.Down);
                    break;
                case GridMultiplicationType.RightUpDiagonal:
                    UpdatePivot(ref pivot, GridMultiplicationType.Right);
                    UpdatePivot(ref pivot, GridMultiplicationType.Up);
                    break;
                default:
                    switch (tp)
                    {
                        case GridMultiplicationType.Down:
                            pivot[0] += 1;
                            if (pivot[0] >= this.Grid.GetUpperBound(1))
                                throw new Exception("Invalid operation");
                            break;
                        case GridMultiplicationType.Up:
                            pivot[0] -= 1;
                            if (pivot[0] < 0)
                                throw new Exception("Invalid operation");
                            break;
                        case GridMultiplicationType.Left:
                            pivot[1] -= 1;
                            if (pivot[1] < 0)
                                throw new Exception("Invalid operation");
                            break;
                        case GridMultiplicationType.Right:
                            pivot[1] += 1;
                            if (pivot[1] >= this.Grid.GetUpperBound(0))
                                throw new Exception("Invalid operation");
                            break;
                    }
                    break;
            }
        }
        /// <summary>
        /// Initialize the grid
        /// </summary>
        private void InitGrid()
        {
            int m, n;
            String[] rows = GRID.Split('@'),
                     cells;
            m = rows.Length;
            n = rows[0].Split(' ').Length;
            this.Grid = new int[m, n];
            for (int i = 0; i < rows.Length; i++)
            {
                cells = rows[i].Split(' ');
                for (int j = 0; j < cells.Length; j++)
                    this.Grid[i, j] = int.Parse(cells[j]);
            }
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid is {0}", this.Result);
        }
    }
}
