using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// You are given the following information, but you may prefer to do some research for yourself.
    /// 1 Jan 1900 was a Monday.
    /// Thirty days has September,
    /// April, June and November.
    /// All the rest have thirty-one,
    /// Saving February alone,
    /// Which has twenty-eight, rain or shine.
    /// And on leap years, twenty-nine.
    /// A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
    /// How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
    /// </summary>
    public class CountingDays
    {
        /// <summary>
        /// The start date
        /// </summary>
        public DateTime StartDate;
        /// <summary>
        /// The end date
        /// </summary>
        public DateTime EndDate;
        /// <summary>
        /// The multple sum result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public CountingDays(DateTime st, DateTime end)
        {
            this.StartDate = st;
            this.EndDate = end;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            long totalSundays = 0;
            DateTime current = this.StartDate;
            while (current != this.EndDate)
            {
                if (current.DayOfWeek == DayOfWeek.Sunday && current.Day == 1)
                    totalSundays += 1;
                current += new TimeSpan(1, 0, 0, 0);
            }
            return totalSundays;
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The  Sundays that fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000) is {0}", this.Result);
        }
    }
}
