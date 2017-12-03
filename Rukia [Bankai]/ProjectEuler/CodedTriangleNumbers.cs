using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// Using p042_words Resource, a 16K  text file containing nearly two-thousand common English words
    /// The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:
    /// 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...
    /// By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value. 
    /// For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. If the word value is a triangle number then we shall call the word a triangle word.
    /// </summary>
    public class CodedTriangleNumbers : ISolution<int>
    {
        /// <summary>
        /// The list of words
        /// </summary>
        List<String> Words;
        /// <summary>
        /// The list of triangle words
        /// </summary>
        List<WordScore> TriangleWords;
        /// <summary>
        /// Return the problem result
        /// </summary>
        public int Result
        {
            get { return Solve(); }
        }
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public CodedTriangleNumbers()
        {
            Words = Resources.Resources.p042_words.Split(',').ToList();
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        public int Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            TriangleWords = new List<WordScore>();
            WordScore word;
            for (int i = 0; i < Words.Count; i++)
            {
                word = new WordScore(Words[i], i + 1);
                if (word.IsTriangleWord)
                    TriangleWords.Add(word);
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return TriangleWords.Count;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The total number of triangle words are {0}", this.Result);
        }
    }
}
