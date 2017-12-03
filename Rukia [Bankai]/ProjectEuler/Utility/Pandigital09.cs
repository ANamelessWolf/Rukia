using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class Pandigital09
    {
                /// <summary>
        /// True if the pandigital follow all the rules
        /// </summary>
        public bool FollowTheRules 
        { 
            get 
            { 
                Boolean flag = true;
                foreach (Pandigital09Rule rule in this.Rules)
                    flag = flag && rule.IsDivisible;
                return flag;
            } 
        }
        /// <summary>
        /// The Pandigital digits
        /// </summary>
        public int[] Digits;
        /// <summary>
        /// The pandigital rules
        /// </summary>
        public List<Pandigital09Rule> Rules;
        /// <summary>
        /// The Number value
        /// </summary>
        public long Number;
        /// <summary>
        /// Creates a new pandigital number created from 0 to 9
        /// </summary>
        /// <param name="number">The string number</param>
        public Pandigital09(String number)
        {
            this.Rules = new List<Pandigital09Rule>();
            Digits = new int[10];
            this.Update(number);
        }
        /// <summary>
        /// Updates the current pandigital number
        /// </summary>
        /// <param name="number">The number to be updated</param>
        public void Update(String number)
        {
            this.Number = long.Parse(number);
            for (int i = 0; i < Digits.Length; i++)
                Digits[i] = int.Parse(number[i].ToString());
        }

        /// <summary>
        /// Adds a new rule to the pandigital number
        /// </summary>
        /// <param name="indexes">The pandigital number</param>
        public void SetRules(Pandigital09Rule[] rules)
        {
            for (int i = 0; i < rules.Length; i++)
                this.Rules.Add(rules[i]);
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return this.Number.ToString();
        }


    }
}
