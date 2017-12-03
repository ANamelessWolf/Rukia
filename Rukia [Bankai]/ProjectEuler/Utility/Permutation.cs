using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class Permutation
    {
        /// <summary>
        /// The list of permutations
        /// </summary>
        public List<String> Permutations;
        /// <summary>
        /// The permutation input
        /// </summary>
        public char[] Sample;
        /// <summary>
        /// Calculates the permutations of string sample
        /// </summary>
        /// <param name="chars">The string to be parsed as character</param>
        public Permutation(String input)
        {
            Permutations = new List<string>();
            this.Sample = input.ToArray();
            this.Generate(this.Sample);
        }
        /// <summary>
        /// Swap two characters
        /// </summary>
        /// <param name="a">The first character to swap</param>
        /// <param name="b">The second character to swap</param>
        private void Swap(ref char a, ref char b)
        {
            char tmp;
            if (a == b)
                return;
            tmp = a;
            a = b;
            b = tmp;
        }
        /// <summary>
        /// Generate the list of permutations
        /// </summary>
        /// <param name="sample">The sample of items to permutate</param>
        private void Generate(char[] sample)
        {
            int size = sample.Length - 1;
            Combine(sample, 0, size);
        }
        /// <summary>
        /// Start the permutation combination
        /// </summary>
        /// <param name="sample">The sample of items to permutate</param>
        /// <param name="currentIndex">The current index</param>
        /// <param name="size">The sample of the size</param>
        private void Combine(char[] sample, int currentIndex, int size)
        {
            int i;
            String s;
            //When the current is equal to the size a permutation is found
            if (currentIndex == size)
            {
                s= new String(sample);
                //Console.Clear();
                //Console.WriteLine(s);
                Permutations.Add(s);
            }
            else
                //Find all recurrencies of the sample
                for (i = currentIndex; i <= size; i++)
                {
                    Swap(ref sample[currentIndex], ref sample[i]);
                    Combine(sample, currentIndex + 1, size);
                    Swap(ref sample[currentIndex], ref sample[i]);
                }
        }

       
    }
}
