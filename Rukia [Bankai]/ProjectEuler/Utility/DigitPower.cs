using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class DigitPower
    {
        /// <summary>
        /// The number used to obtain its digit power
        /// </summary>
        public long Number;
        /// <summary>
        /// The digit power result
        /// </summary>
        public long DigitPowerSum;
        /// <summary>
        /// The power value
        /// </summary>
        public int Power;
        /// <summary>
        /// True if the number can be written as the sum of n powers of their digits.
        /// </summary>
        public Boolean IsDigitablePower { get { return this.Number == this.DigitPowerSum; } }

        /// <summary>
        /// The number digit power
        /// </summary>
        /// <param name="num">The name to test</param>
        public DigitPower(long num, int power)
        {
            this.Number = num;
            this.DigitPowerSum = 0;
            this.Power = power;
            char[] digits = num.ToString().ToCharArray();
            foreach (char digit in digits)
                DigitPowerSum += (long)Math.Pow(double.Parse(digit.ToString()), power);
        }
        /// <summary>
        /// The digit power number result
        /// </summary>
        /// <returns>The number string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('\n');
            sb.Append(this.Number);
            if (IsDigitablePower)
                sb.Append(" = ");
            else
                sb.Append(" != ");
            foreach (char digit in this.Number.ToString().ToCharArray())
                sb.Append(digit + "^" + this.Power + " + ");
            if (IsDigitablePower)
            {
                sb.Remove(sb.ToString().Length - 3,3);
                sb.Append('\n');
                sb.Append(this.Number);
                sb.Append(" = ");
                foreach (char digit in this.Number.ToString().ToCharArray())
                    sb.Append((long)Math.Pow(double.Parse(digit.ToString()), this.Power) + " + ");
            }
            return sb.ToString().Substring(0, sb.ToString().Length - 3);
        }

    }
}
