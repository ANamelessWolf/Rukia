using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public interface ISolution<T>
    {
        T Result { get; }
        T Solve();
       
    }
}
