using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    public class CountingSundays : ISolution
    {
        public int Sundays { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
        public Dictionary<int, int> MonthDays { get; }

        /// <summary>
        /// Counts the number of sundays between dates
        /// </summary>
        /// <param name="st">Start date</param>
        /// <param name="end">End date</param>
        public CountingSundays(DateTime st, DateTime end)
        {
            this.Start = st;
            this.End = end;
            this.MonthDays = new Dictionary<int, int>();
            this.InitMonthDays();
            this.Sundays = this.Solve();
        }

        private void InitMonthDays()
        {
            this.MonthDays.Add(1, 31);
            this.MonthDays.Add(2, 28);
            this.MonthDays.Add(3, 31);
            this.MonthDays.Add(4, 30);
            this.MonthDays.Add(5, 31);
            this.MonthDays.Add(6, 30);
            this.MonthDays.Add(7, 31);
            this.MonthDays.Add(8, 31);
            this.MonthDays.Add(9, 30);
            this.MonthDays.Add(10, 31);
            this.MonthDays.Add(11, 30);
            this.MonthDays.Add(12, 31);
        }

        public string PrintResult()
        {
            return String.Format("The  Sundays that fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000) is {0}", this.Sundays);
        }

        public int Solve()
        {
            int totalSundays = 0;
            DateTime current = this.Start;
            while (current < this.End)
            {
                if (current.DayOfWeek == DayOfWeek.Sunday && current.Day == 1)
                    totalSundays += 1;
                current += new TimeSpan(NextMonth(current), 0, 0, 0);
            }
            return totalSundays;
        }

        public int NextMonth(DateTime date)
        {
            var days = MonthDays[date.Month];

            if (date.Month == 2 && IsLeapYear(date.Year))
                days++;
            return days;
        }

        private bool IsLeapYear(int year)
        {
            return (year % 100 == 0 && year % 400 == 0) ||
                (year % 100 != 0 && year % 4 == 0);
        }
    }
}
