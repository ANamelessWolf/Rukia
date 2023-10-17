using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface
{
    public interface IPrimeTester<T>
    {
        PrimeTestResult QuickTest(T number);
        bool IsPrime(T number);
        
    }
}
