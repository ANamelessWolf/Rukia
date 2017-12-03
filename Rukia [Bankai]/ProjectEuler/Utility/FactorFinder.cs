using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class FactorFinder
    {
        /// <summary>
        /// The value of the Node
        /// </summary>
        public long Value;
        /// <summary>
        /// The total number of factors
        /// </summary>
        public int Count { get { return Factors.Count; } }
        /// <summary>
        /// Factors
        /// </summary>
        public List<long> Factors;
        /// <summary>
        /// Primes
        /// </summary>
        public Dictionary<long, int> Primes;
        /// <summary>
        /// Creates a new Factor node
        /// </summary>
        /// <param name="factors">The list of current factors</param>
        /// <param name="value">The number value</param>
        public FactorFinder(long value)
        {
            this.Value = value;
            Factors = new List<long>();
            Factors.Add(1);
            Primes = new Dictionary<long, int>();
        }
        /// <summary>
        /// Find the factors of the given number
        /// </summary>
        /// <param name="properDivisorFlag">Proper divisors, if true the factors exclude this number as divisor</param>
        internal void Find(Boolean properDivisorFlag = false)
        {
            if (this.Value == 1)
                return;
            if (this.Value == 2 && !properDivisorFlag)
                this.Factors.Add(2);
            else if (this.Value == 2)
                return;
            if (this.Value % 2 == 0)
                this.Factors.Add(2);
            for (int i = 3; i < this.Value; i++)
            {
                if (this.Value % i == 0)
                    this.Factors.Add(i);
            }
            if (!properDivisorFlag)
                Add(ref this.Factors, this.Value);
        }
        internal void FindPrimes(long[] primes)
        {
            this.Primes = new Dictionary<long, int>();
            if (Value == 1)
                return;
            else if (primes.Contains(this.Value))
                this.Primes.Add(this.Value, 1);
            else
            {
                long num = this.Value;
                int count = 0;
                for (int i = 0; num != 1; i++)
                {
                    while (num % primes[i] == 0)
                    {
                        num = num / primes[i];
                        count++;
                    }
                    if (count > 0 && !this.Primes.ContainsKey(primes[i]))
                        this.Primes.Add(primes[i], count);
                    count = 0;
                }
            }
        }
        /// <summary>
        /// Count the factors of the triangle number
        /// </summary>
        internal int CountFactors()
        {
            int count = 1;
            if (this.Value == 1)
                return count;
            if (this.Value % 2 == 0)
                count++;
            for (int i = 3; i <= Math.Sqrt(this.Value); i++)
                if (this.Value % i == 0)
                    count += 2;
            return count;
        }

        /// <summary>
        /// Add a factor if the factor does not exist
        /// </summary>
        /// <param name="factors">The factors to be added</param>
        /// <param name="value">The factor value</param>
        private void Add(ref List<long> factors, long value)
        {
            if (!factors.Contains(value))
                factors.Add(value);
        }

        /// <summary>
        /// Factors
        /// </summary>
        /// <returns>The number factors</returns>
        public override string ToString()
        {
            this.Factors.Sort();
            StringBuilder sb = new StringBuilder();
            sb.Append("Factors: ");
            for (int i = 0; i < this.Count; i++)
                if (i == this.Count - 1)
                    sb.Append(this.Factors[i]);
                else
                {
                    sb.Append(this.Factors[i]);
                    sb.Append(',');
                    sb.Append(' ');
                }
            return sb.ToString();
        }


    }
}
