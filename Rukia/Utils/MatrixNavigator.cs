using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utils
{
    public class MatrixNavigator<T>: IMatrixNavigator<T>
    {
        /// <summary>
        /// The matrix to manipulate
        /// </summary>
        public T[,] Matrix { get; set; }

        public MatrixNavigator(T[,] matrix) 
        { 
            this.Matrix = matrix;
        }

        public T Get(Position p)
        {
            if (p.X < 0 || p.Y < 0)
                return default;
            if (p.Y >= this.Matrix.GetLength(0) || p.X >= this.Matrix.GetLength(1))
                return default;
            return this.Matrix[p.Y, p.X];
        }

        public T[] GetAdjacent(Position pos, Direction d, int size)
        {
            T[] adjacent = new T[size];
            adjacent[0] = this.Get(pos);
            for (int i = 1; i < size; i++)
            {
                pos = this.Move(pos, d);
                adjacent[i] = this.Get(pos);
                if (adjacent[i] == null)
                    return default;
            }
            return adjacent;
        }

        public Position Move(Position p, Direction d)
        {
            switch (d)
            {
                case Direction.up:
                    p.Y -= 1;
                    break;
                case Direction.down:
                    p.Y += 1;
                    break;
                case Direction.left:
                    p.X -= 1;
                    break;
                case Direction.right:
                    p.X += 1;
                    break;
                case Direction.diagonal_up_left:
                    p.Y -= 1;
                    p.X -= 1;
                    break;
                case Direction.diagonal_up_right:
                    p.Y -= 1;
                    p.X += 1;
                    break;
                case Direction.diagonal_down_left:
                    p.Y += 1;
                    p.X -= 1;
                    break;
                case Direction.diagonal_down_right:
                    p.Y += 1;
                    p.X += 1;
                    break;
            }
            return p;
        }

    }

    public struct Position
    {
        public int X;
        public int Y;
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public enum Direction
    {
        up = 0,
        down = 1,
        left = 2,
        right = 3,
        diagonal_up_left = 4,
        diagonal_up_right = 5,
        diagonal_down_left = 6,
        diagonal_down_right = 7
    }

}
