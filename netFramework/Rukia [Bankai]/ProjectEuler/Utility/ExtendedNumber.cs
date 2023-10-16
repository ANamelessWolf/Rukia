using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public static class ExtendedNumber
    {
        public static Boolean IsPalindrome(this long number)
        {
            Boolean flag = true;
            String nStr = number.ToString();
            if (nStr.Length % 2 != 0)
                nStr = nStr.Remove((int)(nStr.Length / 2d), 1);
            Char[] nArr = nStr.ToCharArray();
            for (int i = 0; i < nArr.Length / 2; i++)
            {
                flag &= nArr[i] == nArr[nArr.Length - 1 - i];
                if (!flag)
                    break;
            }
            return flag;
        }
        public static Boolean IsPalindrome(this String nStr)
        {
            Boolean flag = true;
            if (nStr.Length % 2 != 0)
                nStr = nStr.Remove((int)(nStr.Length / 2d), 1);
            Char[] nArr = nStr.ToCharArray();
            for (int i = 0; i < nArr.Length / 2; i++)
            {
                flag &= nArr[i] == nArr[nArr.Length - 1 - i];
                if (!flag)
                    break;
            }
            return flag;
        }
        public static StringNumber ToNumberName(this int number)
        {
            return new StringNumber(number);
        }
        public static string[] ToCircleNumber(this string num)
        {
            String[] numbers = new String[num.Length];
            numbers[0] = num;
            Char[] arr = num.ToArray();
            Char tmp;
            int last = num.Length;
            for (int i = 1; i < num.Length; i++)
            {
                for (int j = 1; j < num.Length; j++)
                {
                    tmp = arr[j - 1];
                    arr[j - 1] = arr[j];
                    arr[j] = tmp;
                }
                numbers[i] = new String(arr);
            }
            return numbers;
        }

        /// <summary>
        /// Return the triangle number
        /// </summary>
        /// <param name="number">The number to test</param>
        /// <returns>True if is a triangle number</returns>
        public static Boolean IsTriangleNumber(int number)
        {
            return TriangleNumberGenerator.IsTriangleNumber(number);
        }
        /// <summary>
        /// Return the pentagonal number
        /// </summary>
        /// <param name="number">The number to test</param>
        /// <returns>True if is a pentagonal number</returns>
        public static Boolean IsPentagonalNumber(int number)
        {
            return PentagonNumbers.IsPentagonalNumber(number);
        }
        /// <summary>
        /// Return the hexagonal number
        /// </summary>
        /// <param name="number">The number to test</param>
        /// <returns>True if is a hexagonal number</returns>
        public static Boolean IsHexagonalNumber(int number)
        {
            return TriangularPentagonalAndHexagonal.IsHexagonalNumber(number);
        }

    }
}
