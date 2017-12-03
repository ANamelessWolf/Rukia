using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class BigOperation
    {
        /// <summary>
        /// The Big number power
        /// </summary>
        /// <param name="num">The number to elevate to a base power</param>
        /// <param name="baseNum">The base number to elevate</param>
        /// <returns>The power result</returns>
        public static BigNumber Pow(long num, long baseNum)
        {
            BigNumber number = BigNumber.Parse(num.ToString());
            long result = 0, intPart = 0,
                 size = (long)Math.Pow(number.size, 10);
            if (baseNum == 0)
                return BigNumber.Parse("1");
            else if (baseNum == 1)
                return number;
            else
            {
                for (long i = 2; i <= baseNum; i++)
                {
                    //Console.Clear();
                    //Console.WriteLine(i-1);
               //     Console.WriteLine(number);
                    for (int j = 0; j < number.Digits.Count; j++)
                    {
                        result = number.Digits[j] * num;
                        result += intPart;
                        intPart = 0;
                        if (result > size)
                        {
                            intPart = (int)(result / size);
                            result = result - intPart * size;
                            if (j + 1 == number.Digits.Count)
                            {
                                number.Digits.Add(intPart);
                                number.Digits[j] = result;
                                intPart = 0;
                                break;
                            }
                        }
                        number.Digits[j] = result;
                    }
                }
            }
            return number;
        }
        /// <summary>
        /// The Big number power
        /// </summary>
        /// <param name="num">The number to elevate to a base power</param>
        /// <param name="baseNum">The base number to elevate</param>
        /// <returns>The power result</returns>
        public static BigNumber Factorial(long num)
        {
            BigNumber number = BigNumber.Parse("1");
            long result = 0, intPart = 0,
                 size = (long)Math.Pow(number.size, 10);
            if (num == 0)
                return BigNumber.Parse("0");
            else if (num == 1)
                return number;
            else
            {
                for (long i = 2; i <= num; i++)
                {
                    Console.Clear();
                    Console.WriteLine(i - 1);
                    //     Console.WriteLine(number);
                    for (int j = 0; j < number.Digits.Count; j++)
                    {
                        result = number.Digits[j] * i;
                        result += intPart;
                        intPart = 0;
                        if (result > size)
                        {
                            intPart = (int)(result / size);
                            result = result - intPart * size;
                            if (j + 1 == number.Digits.Count)
                            {
                                number.Digits.Add(intPart);
                                number.Digits[j] = result;
                                intPart = 0;
                                break;
                            }
                        }
                        number.Digits[j] = result;
                    }
                }
            }
            return number;
        }

    }
}
