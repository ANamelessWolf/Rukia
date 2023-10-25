using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utils
{
    public class StringMatrixNavigator : MatrixNavigator<string>
    {
        public StringMatrixNavigator(string[,] matrix) : base(matrix)
        {
        }

        public int GetAdjacentProduct(Position pos, Direction d, int size)
        {
            int product = int.Parse(this.Matrix[pos.Y, pos.X]);
            string value;
            for (int i = 1; i < size; i++)
            {
                pos = this.Move(pos, d);
                value = this.Get(pos);
                if (value == null)
                    return 0;
                product *= int.Parse(value);
            }
            return product;
        }
    }
}
