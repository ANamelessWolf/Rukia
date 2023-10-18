using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    /// LargestPalindromeProduct
    /// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    /// Find the largest palindrome made from the product of two 3-digit numbers.
    /// </summary>
    public class LargestPalindromeProduct : ISolution
    {
        public int Result;
        private int P1;
        private int P2;

        private readonly int Digits;

        public LargestPalindromeProduct(int digits)
        {
            Digits = digits;
            Result = Solve();
        }

        public string PrintResult()
        {
            return String.Format("The largest palindrome made from the product of \"{0} x {1}\" is {2}", this.P1, this.P2, this.Result);
        }

        public int Solve()
        {
            int max = this.getMaxNumber();
            int p1 = max, p2 = max + 1;
            int testNumber = max * max;
            int size = getSize(testNumber);
            // Mientras el factor 2(p2) sea del tamaño de digitos
            // especificados, continua el algoritmo.
            while (p2 > max && testNumber > 0)
            {
                //Se revisa si el número es palindromo
                if (testNumber.IsPalindrome(size))
                {
                    //Se varia el primer factor desde el máximo hacia abajo
                    p1 = max;
                    while (testNumber % p1 != 0)
                        p1--;
                    //El segundo factor debe ser de los mismos digitos al primero,
                    //si lo es, el problema esta resuelto, en caso contrario
                    //se prueba con otro número.
                    if (testNumber / p1 <= max)
                        p2 = testNumber / p1;
                    else
                        testNumber--;
                }
                else
                    testNumber--;
            }
            //Se obtiene el resultado y los factores que realizan el número
            P1 = p1;
            P2 = p2;
            return testNumber;
        }
        /// <summary>
        /// Se obtiene el tamaño de la división,
        /// este valor se usa para generar la parte izquierda
        /// del palindromo
        /// </summary>
        /// <param name="maxNumber">El numero máximo</param>
        /// <returns>El tamaño de la división</returns>
        private int getSize(int maxNumber)
        {
            int size = 10;
            while (maxNumber / size > 0)
                size *= 10;
            return size / 10;
        }
        /// <summary>
        /// Obtiene el número máximo para el factor
        /// de n digitos.
        /// </summary>
        /// <returns>
        /// El número máximo  
        /// Ejemplo 2 digitos; 99, 3 digitos 999</returns>
        private int getMaxNumber()
        {
            string strNumber = "";
            for (int i = 1; i <= Digits; i++)
                strNumber += 9;
            return int.Parse(strNumber);
        }
    }
}
