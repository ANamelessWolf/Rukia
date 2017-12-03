using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class ProperNumber : IComparable<ProperNumber>
    {
        /// <summary>
        /// Proper number value
        /// </summary>
        public long Number;
        /// <summary>
        /// Proper number type
        /// </summary>
        public ProperNumberType Type;
        /// <summary>
        /// Proper number factors
        /// </summary>
        public List<long> Factors;
        /// <summary>
        /// Proper number
        /// </summary>
        /// <param name="num">The number to be converted as a proper number</param>
        public ProperNumber(long num)
        {
            this.Number = num;
            FactorFinder f = new FactorFinder(num);
            f.Find(true);
            Factors = f.Factors;
            long sum = Factors.Sum<long>(X => X);
            if (sum == this.Number)
                this.Type = ProperNumberType.Perfect;
            else if (sum > this.Number)
                this.Type = ProperNumberType.Abundant;
            else
                this.Type = ProperNumberType.Deficient;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("{0} is {1}", this.Number, this.Type.ToString());
        }

        public int CompareTo(ProperNumber other)
        {
            if (this.Number == other.Number)
                return 0;
            else if (this.Number > other.Number)
                return 1;
            else
                return -1;
        }

        internal bool IsSumOfTwoAbundants(List<ProperNumber> Abundants, List<ProperNumber> OddAbundants, List<ProperNumber> EvenAbundants)
        {
            ProperNumber pNum;
            if (this.Number <= 12)
                return false;
            else if (this.Number > 20161)
                return true;
            else if (this.Number % 2 == 0)
            {
                if (this.Number % 12 == 0)
                    return true;
                else if (this.Number > 18 && this.Number % 18 == 0)
                    return true;
                else if (this.Number > 20 && this.Number % 20 == 0)
                    return true;
                else
                {
                    foreach (ProperNumber pnum in Abundants)
                        if (this.Number - pnum.Number > 0)
                        {
                            pNum = Abundants.Where<ProperNumber>(X => X.Number == (this.Number - pnum.Number)).FirstOrDefault();
                            if (pNum != null)
                                return true;
                        }
                        else
                            return false;
                    return false;
                }
            }
            else
            {
                if (this.Number < 957)
                    return false;
                else
                {
                    foreach (ProperNumber pnum in OddAbundants)
                        if (this.Number - pnum.Number > 0)
                        {
                            pNum = EvenAbundants.Where<ProperNumber>(X => X.Number == (this.Number - pnum.Number)).FirstOrDefault();
                            if (pNum != null)
                                return true;
                        }
                        else
                            return false;
                }
                return false;
            }
        }
    }
}
