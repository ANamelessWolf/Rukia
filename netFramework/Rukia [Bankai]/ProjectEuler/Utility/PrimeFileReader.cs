using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class PrimeFileReader
    {
        const long BLOCK_SIZE = 100000;
        public Dictionary<long, List<long>> Primes;
        /// <summary>
        /// Create a prime dictionary starting from a given range
        /// </summary>
        /// <param name="file">The prime file</param>
        /// <param name="range">The prime range file</param>
        public PrimeFileReader(FileInfo file, long[] range)
        {
            Primes = new Dictionary<long, List<long>>();
            String[] lines = File.ReadAllLines(file.FullName);
            string blockKey;
            String[] primes;
            long key;
            if (File.Exists(file.FullName))
            {
                foreach (String line in lines)
                {
                    if (line.Length > 1)
                    {
                        blockKey = line.Substring(1, line.LastIndexOf(']') - 1);
                        key = long.Parse(blockKey);
                        if ((key > range[0] && key < range[1]) || key == range[0] || key == range[1])
                        {
                            this.Primes.Add(key, new List<long>());
                            primes = line.Substring(blockKey.Length + 2).Split('@');
                            foreach (String prime in primes)
                                this.Primes[key].Add(long.Parse(prime));
                        }
                        else if (this.Primes.Count == 0)
                        {
                            this.Primes.Add(key, new List<long>());
                            primes = line.Substring(blockKey.Length + 2).Split('@');
                            long p;
                            foreach (String prime in primes)
                            {
                                p = long.Parse(prime);
                                if (p >= range[0] && p <= range[1])
                                    this.Primes[key].Add(p);
                            }
                        }
                    }
                }
            }
            else
                Console.WriteLine("El archivo \"{0}\", no existe, verifique el archivo para poder cargar los primos.");
        }
        /// <summary>
        /// Check if a number is prime
        /// </summary>
        /// <param name="prime">The prime number to be tested</param>
        /// <returns>True if the number is prime</returns>
        public Boolean IsPrime(long prime)
        {
            long blockKey = ((long)(prime / BLOCK_SIZE) + 1) * BLOCK_SIZE;
            if (this.Primes.ContainsKey(blockKey))
                return this.Primes[blockKey].Contains(prime);
            else
                throw new Exception("El primo seleccionado no existe en el bloque seleccionado");
        }
        /// <summary>
        /// Return the numbers primes smaller than the number
        /// </summary>
        /// <param name="num">The number to test</param>
        /// <returns>The collection of smaller primes</returns>
        internal long[] SmallerThan(long num)
        {
            List<long> primes = new List<long>();
            foreach (long blockKey in this.Primes.Keys)
            {
                foreach (long prime in this.Primes[blockKey])
                {
                    if (prime < num)
                        primes.Add(prime);
                    else
                        break;
                }
                if (blockKey > num)
                    break;
            }
            return primes.ToArray();
        }
    }
}
