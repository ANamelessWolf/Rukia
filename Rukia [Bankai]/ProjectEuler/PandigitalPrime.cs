using Nameless.Libraries.Rukia.ProjectEuler.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. 
    /// For example, 2143 is a 4-digit pandigital and is also prime.
    /// What is the largest n-digit pandigital prime that exists?
    /// Se usará la ruta del archivo de Primes
    /// </summary>
    public class PandigitalPrime : ISolution<long>
    {
        const String PRIME_PATH = @"..\..\Assets\Primes\";
        const String PRIME_FILE = "50000000.txt";

        PrimeFileReader pReader;

        /// <summary>
        // Check if a number is prime
        /// </summary>
        public PandigitalPrime()
        {
            //Usando la regla de los nueves, que dice que la suma de todos los digitos de un número hasta su ultima expresión,
            //Si el resultado es nueve el número es divisible entre 9.
            //Por lo tanto no hay pandigital de n=9 y n=8
            //El más grande debe estar n=7
            pReader = new PrimeFileReader(new FileInfo(Path.Combine(PRIME_PATH, PRIME_FILE)), new long[] { 7000000, 8000000 });

        }
        /// <summary>
        /// Return the Result
        /// </summary>
        public long Result
        {
            get { return Solve(); }
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The problem solution</returns>
        public long Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            long largest = 0;
            foreach (long block in pReader.Primes.Keys)
                foreach (long prime in pReader.Primes[block])
                {
                    if (prime > largest && IsPandigital(prime))
                        largest = prime;
                }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return largest;
        }

        private bool IsPandigital(long prime)
        {
            if (prime.ToString().Contains('0'))
                return false;
            else
            {
                return
                    prime.ToString().Contains('1') &&
                    prime.ToString().Contains('2') &&
                    prime.ToString().Contains('3') &&
                    prime.ToString().Contains('4') &&
                    prime.ToString().Contains('5') &&
                    prime.ToString().Contains('6') &&
                    prime.ToString().Contains('7');
            }
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The largest n-digit pandigital prime that exists is {0}", this.Result);
        }
    }
}
