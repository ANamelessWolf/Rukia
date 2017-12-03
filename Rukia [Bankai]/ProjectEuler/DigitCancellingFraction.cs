using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// The fraction 49/98 is a curious fraction, as an inexperienced mathematician in attempting to simplify it may incorrectly believe that 49/98 = 4/8, which is correct, 
    /// is obtained by cancelling the 9s.
    /// We shall consider fractions like, 30/50 = 3/5, to be trivial examples.
    /// There are exactly four non-trivial examples of this type of fraction, less than one in value, and containing two digits in the numerator and denominator.
    /// If the product of these four fractions is given in its lowest common terms, find the value of the denominator.
    /// </summary>
    public class DigitCancellingFraction : ISolution<int>
    {
        /// <summary>
        /// The list of fraction result
        /// </summary>
        public List<String> FractionResult;
        /// <summary>
        /// Create a new Digit Cancelling fraction
        /// </summary>
        public DigitCancellingFraction()
        {

        }

        /// <summary>
        /// Return the digit cancelling solution
        /// </summary>
        public int Result
        {
            get { return Solve(); }
        }
        /// <summary>
        /// Solve the current problem
        /// </summary>
        /// <returns>The solution</returns>
        public int Solve()
        {
            FractionResult = new List<string>();
            long denproduct = 1, nomproduct = 1;
            int aNum, bNum;
            for (int i = 10; i < 99; i++)
                for (int j = i; j <= 99; j++)
                {
                    if (i == j || (i % 10 == 0 && j % 10 == 0))
                        continue;
                    else if (CheckDigitValidation((double)i / (double)j, i.ToString().ToCharArray(), j.ToString().ToCharArray(), out  aNum, out  bNum))
                    {
                        FractionResult.Add(aNum.ToString() + "/" + bNum.ToString());
                        nomproduct *= aNum;
                        denproduct *= bNum;
                    }
                }
            GetMinFraction(ref nomproduct, ref denproduct);
            return (int)denproduct;
        }
        /// <summary>
        /// Get the minimum fraction
        /// </summary>
        /// <param name="num">The numerator</param>
        /// <param name="den">The denominator</param>
        private void GetMinFraction(ref long num, ref long den)
        {
            FactorFinder f1 = new FactorFinder(num),
            f2 = new FactorFinder(den);
            f1.Find(true);
            f2.Find(true);
            double val = 1;
            foreach (var v in f1.Factors.Intersect(f2.Factors))
                val *= v;
            num = (int)((double)num / val);
            den = (int)((double)den / val);
        }
        /// <summary>
        /// Check if the digit validation is valid
        /// </summary>
        /// <param name="res">The double result to compare</param>
        /// <param name="a">The first list of array</param>
        /// <param name="b">The second list of array</param>
        /// <returns></returns>
        private bool CheckDigitValidation(double res, char[] aDigits, char[] bDigits, out int aNum, out int bNum)
        {
            double r = 0;
            aNum = 0;
            bNum = 0;
            string num, den;
            if (aDigits.Length == bDigits.Length)
            {
                for (int b = 0; b < bDigits.Length; b++)
                {
                    num = new String(aDigits).Replace(bDigits[b].ToString(), "");
                    den = new String(bDigits).Replace(bDigits[b].ToString(), "");
                    if (num == String.Empty)
                        num += aDigits[0];
                    if (den == String.Empty)
                        den += bDigits[0];
                    else if (den == "0")
                        r = 0;
                    else
                        r = double.Parse(num) / double.Parse(den);
                    if (res == r)
                    {
                        aNum = int.Parse(num);
                        bNum = int.Parse(den);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The product of these four fractions by its lowest common terms has a denominator of {0}", this.Result);
        }
    }
}
