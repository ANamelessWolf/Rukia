using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface
{
    public interface IMatrixNavigator<T>
    {
        T[,] Matrix { get; set; }

        T Get(Position p);

        T[] GetAdjacent(Position pos, Direction d, int size);

        Position Move(Position p, Direction d);
    }
}
