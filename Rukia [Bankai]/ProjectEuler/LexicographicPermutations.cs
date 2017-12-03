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
    /// A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. 
    /// If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. 
    /// The lexicographic permutations of 0, 1 and 2 are: 012   021   102   120   201   210
    /// What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?
    /// </summary>
    public class LexicographicPermutations
    {
        const int ONE_MILLION = 1000000;
        /// <summary>
        /// The Lexicographic sample
        /// </summary>
        public String Input;
        /// <summary>
        /// The factorial result
        /// </summary>
        public String Result { get { return Solve(); } }
        /// <summary>
        /// Create a list of permutations
        /// </summary>
        /// <param name="input">The lexicographic character sample</param>
        public LexicographicPermutations(String input = "0123456789")
        {
            this.Input = input;
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private String Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Permutation p = new Permutation(this.Input);
            p.Permutations.Sort();
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return p.Permutations.Count > ONE_MILLION - 1 ? p.Permutations[ONE_MILLION - 1] : String.Empty;
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The millionth lexicographic permutation of the chars {0} is {1}", this.Input, this.Result);
        }
    }
}
