using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface
{
    public interface ISolution
    {
        int Solve();
        string PrintResult();
    }
      public interface ILongSolution
    {
        long Solve();
        string PrintResult();
    }
}
