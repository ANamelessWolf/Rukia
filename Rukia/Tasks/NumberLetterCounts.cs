using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    public class NumberLetterCounts : ISolution
    {
        public int Limit { get; }
        public int Count { get; }


        public NumberLetterCounts(int limit)
        {
            this.Limit = limit;
            this.Count = this.Solve();
        }

        public string PrintResult()
        {
            return String.Format("The numbers from 1 to {0} inclusive written in words, had a total of {1}", this.Count, this.Limit);
        }

        public int Solve()
        {
            int count = 0;
            for (int i = 1; i <= this.Limit; i++)
                count += this.CountLetters(i);
            return count;
        }

        public int CountLetters(int number)
        {
            var engNum = number.ToEnglish();
            return engNum.Replace(" ", "").Replace("-", "").Length;
        }
    }
}
