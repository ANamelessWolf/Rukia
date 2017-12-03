using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class SquareTwoConvergent
    {
        /// <summary>
        /// The convergent fractions, on a value pair Key
        /// Numerator, Denominator
        /// </summary>
        public List<BigNumber[]> Fractions;
        BigNumber Numerator, Denominator;
        /// <summary>
        /// Creates a new square two convergentions
        /// </summary>
        public SquareTwoConvergent()
        {
            this.Numerator = BigNumber.Parse("2");
            this.Denominator = BigNumber.Parse("5");
            Fractions = new List<BigNumber[]>();
            Fractions.Add(new BigNumber[] { BigNumber.Parse("1"), BigNumber.Parse("2") });
            Fractions.Add(new BigNumber[] { this.Numerator, this.Denominator });
        }
        /// <summary>
        /// Adds ones two the Square convertion fractions
        /// </summary>
        public void AddOne()
        {
            this.Fractions =
                this.Fractions.Select<BigNumber[], BigNumber[]>
                (x => new BigNumber[] { x[0] + x[1], x[1] }).ToList();
            this.Numerator += this.Denominator;
        }
        /// <summary>
        /// Creates a new square two convergentions with a limit
        /// iteration
        /// </summary>
        public SquareTwoConvergent(int iteration)
            : this()
        {
            BigNumber tmp;
            for (int i = 1; i <= iteration; i++)
            {
                this.Numerator += (this.Denominator + this.Denominator);
                tmp = this.Denominator;
                this.Denominator = this.Numerator;
                this.Numerator = tmp;
                Fractions.Add(new BigNumber[] { this.Numerator, this.Denominator });
            }
        }
    }
}
