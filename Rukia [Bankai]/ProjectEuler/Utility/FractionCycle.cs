using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class FractionCycle
    {
        /// <summary>
        /// The fraction number cycle
        /// </summary>
        public int Num;
        /// <summary>
        /// The number fraction
        /// </summary>
        public String Fraction;
        /// <summary>
        /// The recurrent cycle
        /// </summary>
        public String RecurrentCycle;
        /// <summary>
        /// The size of the recurrent cycle count
        /// </summary>
        public int Count { get { return this.RecurrentCycle.Length; } }
        /// <summary>
        /// Initialize the fraction cycle
        /// </summary>
        public FractionCycle(int num)
        {
            this.Num = num;
            int cycleIndex, cycleSize;
            CalculateReminders(out cycleIndex, out cycleSize);
            Divide(1, this.Num, cycleIndex, cycleSize, out this.Fraction, out this.RecurrentCycle);
        }
        /// <summary>
        /// Divide the decimal
        /// </summary>
        /// <param name="divider">The decimal divider</param>
        /// <param name="divisor">The decimal divisor</param>
        /// <param name="cycleIndex">The cycle start index</param>
        /// <param name="cycleSize">The cycle size</param>
        /// <param name="fraction">The output is the fraction result</param>
        /// <param name="cycle">The output is the cycle result</param>
        private void Divide(int divider, int divisor, int cycleIndex, int cycleSize, out string fraction, out string cycle)
        {
            int b, count = 0;
            fraction = String.Empty;
            cycle = String.Empty;
            Boolean flag = true;
            do
            {
                divider *= 10;
                b = divider / divisor;
                divider = divider - b * divisor;
                if (count < cycleIndex || cycleSize == 0)
                    fraction += b;
                else
                    cycle += b;
                count++;
                if ((cycle.Length == cycleSize && cycle.Length > 0) || divider == 0)
                    flag = false;
            } while (flag);
        }
        /// <summary>
        /// Calculates the function reminders
        /// </summary>
        /// <param name="cycleIndex">The fraction cycle reminder</param>
        /// <param name="cycleSize">The fraction cycle size</param>
        private void CalculateReminders(out int cycleIndex, out int cycleSize)
        {
            List<int> reminders = new List<int>();
            Boolean diffReminder = true;
            int rem, divider = 1;
            cycleIndex = 0;
            cycleSize = 0;
            while (diffReminder)
            {
                //Calculates the reminder and waits to be repeated
                rem = divider % this.Num;
                divider = rem * 10;
                if (rem != 0)
                {
                    if (reminders.Contains(rem))
                    {
                        diffReminder = false;
                        cycleIndex = reminders.IndexOf(rem);
                    }
                    else
                        reminders.Add(rem);
                    cycleSize = reminders.Count - cycleIndex;
                }
                else
                {
                    //If the reminder is 0 is not a periodical fraction
                    diffReminder = false;
                    cycleSize = 0;
                }

            }
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            if (this.RecurrentCycle == String.Empty)
                return String.Format("0.{0}", this.Fraction);
            else
                return String.Format("0.{0}({1})", this.Fraction, this.RecurrentCycle);
        }
    }
}
