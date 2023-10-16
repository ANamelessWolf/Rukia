using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class AmicableNumber
    {
        /// <summary>
        /// The number value
        /// </summary>
        public long Number;
        /// <summary>
        /// The amicable number
        /// </summary>
        public long Amicable;
        /// <summary>
        /// True if the number is amicable
        /// </summary>
        public Boolean IsAmicable;
        /// <summary>
        /// Creates a new amicable number
        /// </summary>
        /// <param name="num">The amicable number</param>
        public AmicableNumber(long num)
        {
            long sum1, sum2;
            this.Number = num;
            FactorFinder f = new FactorFinder(num);
            f.Find();
            f.Factors.RemoveAt(f.Factors.Count - 1);
            sum1 = f.Factors.Sum<long>(x => x);
            f = new FactorFinder(sum1);
            f.Find();
            f.Factors.RemoveAt(f.Factors.Count - 1);
            sum2 = f.Factors.Sum<long>(x => x);
            this.Amicable = sum1;
            if (this.Number == sum2 && this.Amicable != this.Number)
                this.IsAmicable = true;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("A: {0} B: {1}", this.Number, this.Amicable);
        }
    }
}
