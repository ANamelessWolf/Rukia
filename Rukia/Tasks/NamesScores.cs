using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using Nameless.Libraries.Rukia.ProjectEuler.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    /// Using p022_names Resource, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
    /// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
    /// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. 
    /// So, COLIN would obtain a score of 938 × 53 = 49714.
    /// What is the total of all the name scores in the file?
    /// </summary>
    public class NamesScores : ILongSolution
    {

        String[] Names { get; }

        /// <summary>
        /// The multple sum result
        /// </summary>
        public long Result { get; }

        public NamesScores()
        {
            var nameStr = File.ReadAllText("assets/0022_names.txt");
            nameStr = nameStr.Replace("\"", "");
            this.Names = nameStr.Split(',');
            this.Result = Solve();
        }

        public string PrintResult()
        {
            return String.Format("The total of all the name scores in the file is {0}", this.Result);
        }

        public long Solve()
        {
            MergeSort sorter = new MergeSort();
            sorter.Sort(this.Names);
            long score = 0;
            for (int i = 0; i < this.Names.Length; i++)
                score += this.Names[i].WordScore() * (i + 1);
            return score;
        }
    }
}
