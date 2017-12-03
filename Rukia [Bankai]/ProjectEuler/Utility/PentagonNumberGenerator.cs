using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class PentagonNumberGenerator
    {
        /// <summary>
        /// The n numbers of wanted numbers
        /// </summary>
        public long Limit;
        /// <summary>
        /// The found numbers
        /// </summary>
        public List<long> Numbers;
        public long Sum;

        /// <summary>
        /// Return the last number
        /// </summary>
        public long Last { get { return this.Numbers[this.Numbers.Count - 1]; } }
        /// <summary>
        /// Generate a list of  numbers
        /// </summary>
        /// <param name="max">The maximum number of  numbers</param>
        public PentagonNumberGenerator(long max = 3)
        {
            this.Limit = max;
            this.Numbers = new List<long>();
            for (int i = 1; i <= this.Limit; i++)
                this.Numbers.Add(TriangleNumberGenerator.Get(i));
        }

        /// <summary>
        /// Gets the triangle number
        /// </summary>
        /// <param name="index">The index of the triangle number to extract</param>
        /// <returns>The triangle number</returns>
        public static long Get(int index)
        {
            return (index * (3 * index - 1)) / 2;
        }
    }
}
