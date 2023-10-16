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
    /// The number, 1406357289, is a 0 to 9 pandigital number because it is made up of each of the digits 0 to 9 in some order, 
    /// but it also has a rather interesting sub-string divisibility property.
    /// Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:
    /// d2d3d4=406 is divisible by 2
    /// d3d4d5=063 is divisible by 3
    /// d4d5d6=635 is divisible by 5
    /// d5d6d7=357 is divisible by 7
    /// d6d7d8=572 is divisible by 11
    /// d7d8d9=728 is divisible by 13
    /// d8d9d10=289 is divisible by 17
    /// Find the sum of all 0 to 9 pandigital numbers with this property.
    /// </summary>
    public class SubStringDivisibility : ISolution<long>
    {
        /// <summary>
        /// The pandigital number rules
        /// </summary>
        Pandigital09Rule[] Rules;
        /// <summary>
        /// The pandigital number
        /// </summary>
        Pandigital09 Pandigital;
        /// <summary>
        /// the list of Numbers that follow the rules
        /// </summary>
        List<long> PandigitalNumbers;

        /// <summary>
        /// Creates a new substring divisibility Number
        /// </summary>
        public SubStringDivisibility()
        {
            this.PandigitalNumbers = new List<long>();
            Pandigital = new Pandigital09("1234567890");
            Rules = new Pandigital09Rule[]
                {
                    new Pandigital09Rule(2, Pandigital, 2, 3, 4),
                    new Pandigital09Rule(3, Pandigital, 3, 4, 5),
                    new Pandigital09Rule(5, Pandigital, 4, 5, 6),
                    new Pandigital09Rule(7, Pandigital, 5, 6, 7),
                    new Pandigital09Rule(11, Pandigital, 6, 7, 8),
                    new Pandigital09Rule(13, Pandigital, 7, 8, 9),
                    new Pandigital09Rule(17, Pandigital, 8, 9, 10),
                };
            this.Pandigital.SetRules(this.Rules);
        }
        /// <summary>
        /// Return the problem solution
        /// </summary>
        public long Result
        {
            get { return this.Solve(); }
        }
        /// <summary>
        /// Solves the problem
        /// </summary>
        /// <returns>The problem solution</returns>
        public long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Permutation p = new Permutation("1234567890");
            foreach (String number in p.Permutations)
            {
                if (number[0] != '0')
                {
                    this.Pandigital.Update(number);
                    if (this.Pandigital.FollowTheRules)
                        this.PandigitalNumbers.Add(this.Pandigital.Number);
                }
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return this.PandigitalNumbers.Sum();
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The sum of all 0 to 9 pandigital numbers with this property are {0} ", this.Result);
        }
    }
}
