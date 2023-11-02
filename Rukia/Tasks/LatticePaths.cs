using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System.Diagnostics;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    public class LatticePaths : MatrixNavigator<int>, ILongSolution
    {
        public long Routes { get; }

        public LatticePaths(int size)
            : base(new int[size, size])
        {
            this.Matrix[size - 1, size - 1] = 1;
            this.Routes = this.Solve();
        }

        public string PrintResult()
        {
            return $"The number of routes are {this.Routes}";
        }

        public long Solve()
        {
            long routes = 0;
            //Solución recursiva, funciona con pocas iteraciones
            if (this.Matrix.GetLength(0) < 5)
                Move(ref routes, new Position() { X = 0, Y = 0 });
            else
            {
                //Solución combinatoria O(n)
                /* C(m,n) = m!/(n!(m-n)!
                 * n = matrix size
                 * m = 2n
                 * Al abrir el grid se obtiene el triangulo de Pascal
                          1
                         1 1
                        1 2 1 (1x1)
                       1 3 3 1
                      1 4 6 4 1 (2x2)
                    1 5 10 10 5 1
                   1 6 15 20 15 6 1 (3x3)
                 */
                routes = 1;
                int n = this.Matrix.GetLength(0);
                for(int i=1; i<= n; i++)
                    routes = routes * (n + i) / i;
            }
            return routes;
        }

        public void Move(ref long routes, Position p)
        {
            Debug.WriteLine(p);
            if (p.X < this.Matrix.GetLength(1))
                Move(ref routes, Move(p, Direction.right));
            if (p.Y < this.Matrix.GetLength(0))
                Move(ref routes, Move(p, Direction.down));
            if (p.X == this.Matrix.GetLength(0) && p.Y == this.Matrix.GetLength(1))
                routes++;
        }
    }
}
