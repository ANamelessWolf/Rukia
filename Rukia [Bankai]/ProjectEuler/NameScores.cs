using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// Using p022_names Resource, a 46K text file containing over five-thousand first names, begin by sorting it into alphabetical order. 
    /// Then working out the alphabetical value for each name, multiply this value by its alphabetical position in the list to obtain a name score.
    /// For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 938th name in the list. 
    /// So, COLIN would obtain a score of 938 × 53 = 49714.
    /// What is the total of all the name scores in the file?
    /// </summary>
    public class NameScores
    {
        List<String> Names;
        List<WordScore> Scores;
        /// <summary>
        /// The multple sum result
        /// </summary>
        public long Result { get { return Solve(); } }
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public NameScores()
        {
            this.InitNames();
        }

        private void InitNames()
        {
            Names = Resources.Resources.p022_names.Split(',').ToList();
            Names.Sort();
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private long Solve()
        {
            Scores = new List<WordScore>();
            for (int i = 0; i < Names.Count; i++)
                Scores.Add(new WordScore(Names[i], i + 1));
            return Scores.Sum<WordScore>(x => x.Score);
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The total of all the name scores in the file is {0}", this.Result);
        }
    }
}
