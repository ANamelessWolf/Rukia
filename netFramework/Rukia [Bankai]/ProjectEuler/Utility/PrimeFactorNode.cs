using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class PrimeFactorNode
    {
        /// <summary>
        /// Factor Parent
        /// </summary>
        public PrimeFactorNode Parent;
        /// <summary>
        /// Factor Parent
        /// </summary>
        public PrimeFactorNode Left { get { return this.Children.Length == 2 ? Children[0] : null; } }
        /// <summary>
        /// Factor Parent
        /// </summary>
        public PrimeFactorNode Right { get { return this.Children.Length == 2 ? Children[1] : null; } }
        /// <summary>
        /// Number is prime
        /// </summary>
        public Boolean IsPrime { get { return this.Children.Length == 0; } }
        /// <summary>
        /// The Factor Found
        /// </summary>
        public long factors;
        /// <summary>
        /// The factors of the number
        /// </summary>
        /// <param name="factors">The found factors</param>
        public void GetFactors(ref List<long> factors)
        {
            if (this.IsPrime)
                factors.Add(this.Value);
            if (this.Left != null)
                this.Left.GetFactors(ref factors);
            if (this.Right != null)
                this.Right.GetFactors(ref factors);
        }

        /// <summary>
        /// The value of the Node
        /// </summary>
        public long Value;
        /// <summary>
        /// The max prime founded in the number
        /// </summary>
        public long MaxPrime { get { return GetMaxPrime(this.Children).Value; } }
        /// <summary>
        /// Gets the max prime of the given number
        /// </summary>
        /// <param name="nodes">The factor node</param>
        /// <returns>The max factor prime</returns>
        private PrimeFactorNode GetMaxPrime(PrimeFactorNode[] nodes)
        {
            if (nodes.Length == 0)
                return this;
            else if (nodes[1].Right != null)
                return GetMaxPrime(nodes[1].Right.Children);
            return nodes[1];
        }
        /// <summary>
        /// The factor children nodes
        /// </summary>
        PrimeFactorNode[] Children;

        /// <summary>
        /// Creates a new Factor node
        /// </summary>
        /// <param name="value">The number value</param>
        public PrimeFactorNode(long value, long defaultFactor = 2)
        {
            this.Parent = null;
            this.Value = value;
            this.Children = new PrimeFactorNode[0];
            this.Add(defaultFactor, value);
        }
        /// <summary>
        /// Adds a new value to the node
        /// </summary>
        /// <param name="lastFactor">The last used factor</param>
        /// <param name="value">The value to test</param>
        private void Add(long lastFactor, long value)
        {
            if (lastFactor == value)
                return;
            else if (value % lastFactor == 0)
            {
                PrimeFactorNode n1 = new PrimeFactorNode(lastFactor, lastFactor);
                PrimeFactorNode n2 = new PrimeFactorNode((long)(value / lastFactor), lastFactor);
                n1.Parent = this;
                n2.Parent = this;
                this.Children = new PrimeFactorNode[] { n1, n2 };
            }
            else
                this.Add(lastFactor + 1, value);

        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            if (IsPrime)
                return String.Format("Node({0}) Prime Number", this.Value);
            else
                return String.Format("Node({0}) Factors: \"{1} x {2}\"", this.Value, this.Left.Value, this.Right.Value);
        }
    }
}
