using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class SpiralMatrix
    {
        /// <summary>
        /// Spiral matrix must have an order of an odd number
        /// </summary>
        public long Order;
        /// <summary>
        /// Spiral matrix Level
        /// </summary>
        public long Level;
        /// <summary>
        /// The spiral matrix sum result
        /// </summary>
        public BigNumber MatrixSum;
        /// <summary>
        /// Creates an spiral matrix
        /// </summary>
        public SpiralMatrix(int order = 1)
        {
            this.Order = order;
            MatrixAction();
        }
        /// <summary>
        /// The matrix action, by default it sums the matrix diagonal members
        /// </summary>
        public virtual void MatrixAction()
        {
            long index = 4;
            long current = 1;
            MatrixSum = BigNumber.Parse(current.ToString());
            while (!(Level == this.Order && index == 4))
            {
                current = Next(ref index, current);
                MatrixSum = MatrixSum + BigNumber.Parse(current.ToString());
            }
        }
        /// <summary>
        /// Return the next member
        /// </summary>
        /// <param name="level">The current level</param>
        /// <param name="current">The current member</param>
        /// <param name="index">The current member index</param>
        /// <returns>The next member</returns>
        public long Next(ref long index, long current)
        {
            if (index == 4)
            {
                this.Level += 2;
                index = 0;
            }
            index++;
            return current + this.Level - 1;
        }


    }
}
