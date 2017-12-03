using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    public class CollatzSequence
    {
        /// <summary>
        /// The number limit
        /// </summary>
        public long Number;
        /// <summary>
        /// The multple sum result
        /// </summary>
        public long Size { get { return Terms.Count; } }
        /// <summary>
        /// The multple sum result
        /// </summary>
        public List<long> Terms;
        /// <summary>
        /// Get the largest prime factor for the given number
        /// </summary>
        /// <param name="number">The number to extract it prime factor</param>
        public CollatzSequence(long number)
        {
            this.Number = number;
            this.Terms = new List<long>();
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        public void Find()
        {
            long i = this.Number;
            Terms = new List<long>();
            Terms.Add(this.Number);
            while (i != 1)
            {
                if (i % 2 == 0)
                    Terms.Add(GetNextAsEven(i));
                else
                    Terms.Add(GetNextAsOdd(i));
                i = Terms[Terms.Count - 1];
            }
        }
        /// <summary>
        /// Gets the next Collatz numberterm if the current number is Even
        /// </summary>
        /// <param name="number">The current collatz number as even</param>
        /// <returns>The next collatz number</returns>
        public long GetNextAsEven(long number)
        {
            return number / 2;
        }
        /// <summary>
        /// Gets the next Collatz numberterm if the current number is Odd
        /// </summary>
        /// <param name="number">The current collatz number as odd</param>
        /// <returns>The next collatz number</returns>
        public long GetNextAsOdd(long number)
        {
            return 3 * number + 1;
        }

    }
}
