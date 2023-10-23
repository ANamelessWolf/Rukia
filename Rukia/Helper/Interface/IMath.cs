using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface
{
    public interface IMath<T>
    {
        T Power(T number, int power);
        T SquareRoot(T number);
        T NextRandom(T minValue, T maxValue);
        T Mod(T number, T div);
        T ModPow(T value, T exponent, T modulus);
    }
}
