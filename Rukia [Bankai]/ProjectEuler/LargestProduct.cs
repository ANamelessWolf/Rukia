using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
    /// Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
    /// </summary>
    public class LargestProduct
    {
        const String NUMBER_SERIES =
            "73167176531330624919225119674426574742355349194934" +
            "96983520312774506326239578318016984801869478851843" +
            "85861560789112949495459501737958331952853208805511" +
            "12540698747158523863050715693290963295227443043557" +
            "66896648950445244523161731856403098711121722383113" +
            "62229893423380308135336276614282806444486645238749" +
            "30358907296290491560440772390713810515859307960866" +
            "70172427121883998797908792274921901699720888093776" +
            "65727333001053367881220235421809751254540594752243" +
            "52584907711670556013604839586446706324415722155397" +
            "53697817977846174064955149290862569321978468622482" +
            "83972241375657056057490261407972968652414535100474" +
            "82166370484403199890008895243450658541227588666881" +
            "16427171479924442928230863465674813919123162824586" +
            "17866458359124566529476545682848912883142607690042" +
            "24219022671055626321111109370544217506941658960408" +
            "07198403850962455444362981230987879927244284909188" +
            "84580156166097919133875499200524063689912560717606" +
            "05886116467109405077541002256983155200055935729725" +
            "71636269561882670428252483600823257530420752963450";
        /// <summary>
        /// The size of adjacent digits in the 1000-digit number
        /// </summary>
        public int GroupSize;
        /// The sum limit
        /// </summary>
        public String Digits;
        /// <summary>
        /// The multple sum result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public LargestProduct(int size = 13)
        {
            this.GroupSize = size;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            Char[] chs = NUMBER_SERIES.ToCharArray();
            long num = 0;
            Digits = String.Empty;
            long tmp, result = 0;
            for (int i = 0; i < chs.Length - this.GroupSize; i++)
            {
                tmp = 1;
                Digits = String.Empty;
                for (int j = 0; j < this.GroupSize; j++)
                {
                    Digits += chs[j + i];
                    if (j != this.GroupSize - 1)
                        Digits += ", ";
                    num = Convert.ToInt32(chs[j + i].ToString());
                    tmp *= num;
                }
                if (tmp > result)
                    result = tmp;
            }
            return result;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The the thirteen adjacent digits in the 1000-digit, the value of this product is {0}", this.Result);
        }
    }
}
