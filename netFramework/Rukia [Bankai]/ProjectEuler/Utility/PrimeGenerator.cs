using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class PrimeGenerator
    {
        /// <summary>
        /// The n numbers of wanted primes
        /// </summary>
        public long Limit;
        /// <summary>
        /// The total number of primes
        /// </summary>
        public List<long> Primes;
        Boolean SumFlag;
        public long Sum;

        /// <summary>
        /// Return the last prime number
        /// </summary>
        public long Last { get { return this.Primes[this.Primes.Count - 1]; } }
        /// <summary>
        /// Generate a list of prime numbers
        /// </summary>
        /// <param name="maxPrime">The maximum number of prime numbers</param>
        public PrimeGenerator(long maxPrime = 3)
        {
            this.Limit = maxPrime;
            this.Primes = new List<long>();
            FillPrimes();
        }

        /// <summary>
        /// Generate a list of prime numbers and save it to a file
        /// </summary>
        /// <param name="maxPrime">The maximum number of prime numbers</param>
        public PrimeGenerator(long maxPrime, FileInfo file)
        {
            this.Limit = maxPrime;
            this.Primes = new List<long>();
            FillPrimes(file);
        }


        /// <summary>
        /// Generate a list of prime numbers
        /// </summary>
        /// <param name="maxPrime">The maximum number of prime numbers</param>
        public PrimeGenerator(long numBreak, Boolean sum = false)
        {
            this.Limit = numBreak;
            this.Primes = new List<long>();
            this.Sum = 0;
            SumFlag = sum;
            FillPrimes(numBreak);
        }

        /// <summary>
        /// Generate a list of prime numbers
        /// </summary>
        /// <param name="maxPrime">The maximum number of prime numbers</param>
        public PrimeGenerator(long lessThan, out long primeCount)
        {
            this.Limit = lessThan;
            this.Primes = new List<long>();
            this.Sum = 0;
            SumFlag = false;
            FillPrimes(lessThan);
            primeCount = this.Primes.Count;
        }

        private void FillPrimes(long numBreak)
        {
            this.Primes.Add(2);
            this.Primes.Add(3);
            this.Sum = 5;
            long number = 3;
            int currentCount;
            double limit;
            Boolean add = true;
            while (number < this.Limit)
            {
                currentCount = this.Primes.Count;
                number = this.Primes[currentCount - 1];
                do
                {
                    number += 2;
                    if (number > this.Limit)
                        break;
                    limit = Math.Sqrt(number);
                    //Check if is divisible by other numbers
                    foreach (long prime in this.Primes)
                    {
                        if (number % prime == 0)
                        {
                            add = false;
                            break;
                        }
                        if (prime > limit)
                            break;
                    }
                    //Add if is prime
                    if (add)
                    {
                        this.Primes.Add(number);
                        if (this.SumFlag)
                        {
                            Sum += number;
                            //Console.Clear();
                            //Console.WriteLine(number);
                            //Console.WriteLine(Sum);
                        }
                    }
                    add = true;
                } while (currentCount == this.Primes.Count);
            }
        }

        private void FillPrimesLessthan(long numBreak)
        {
            this.Primes.Add(2);
            this.Primes.Add(3);
            this.Sum = 5;
            long number = 3;
            int currentCount;
            double limit;
            Boolean add = true;
            while (this.Primes[this.Primes.Count - 1] < numBreak)
            {
                currentCount = this.Primes.Count;
                number = this.Primes[currentCount - 1];
                do
                {
                    number += 2;
                    if (number > this.Limit)
                        break;
                    limit = Math.Sqrt(number);
                    //Check if is divisible by other numbers
                    foreach (long prime in this.Primes)
                    {
                        if (number % prime == 0)
                        {
                            add = false;
                            break;
                        }
                        if (prime > limit)
                            break;
                    }
                    //Add if is prime
                    if (add)
                    {
                        this.Primes.Add(number);
                        if (this.SumFlag)
                        {
                            Sum += number;
                            //Console.Clear();
                            //Console.WriteLine(number);
                            //Console.WriteLine(Sum);
                        }
                    }
                    add = true;
                } while (currentCount == this.Primes.Count);
            }
        }


        /// <summary>
        /// Fill the list of primes
        /// </summary>
        private void FillPrimes()
        {
            this.Primes.Add(2);
            this.Primes.Add(3);
            long number = 3;
            int currentCount;
            double limit;
            Boolean add = true;
            while (this.Primes.Count < this.Limit)
            {
                currentCount = this.Primes.Count;
                number = this.Primes[currentCount - 1];
                do
                {
                    number += 2;
                    limit = Math.Sqrt(number);
                    //Check if is divisible by other numbers
                    foreach (long prime in this.Primes)
                    {
                        if (number % prime == 0)
                        {
                            add = false;
                            break;
                        }
                        if (prime > limit)
                            break;
                    }
                    //Add if is prime
                    if (add)
                    {
                        this.Primes.Add(number);
                        Console.WriteLine(number + ", ");
                    }
                    add = true;

                } while (currentCount == this.Primes.Count);
            }
        }


        /// <summary>
        /// Fill the list of primes
        /// </summary>
        private void FillPrimes(FileInfo file)
        {
            const int BLOCK_SIZE = 100000;
            int blockCount = 0;
            int fileIndex = 1;
            this.Primes.Add(2);
            this.Primes.Add(3);
            int block = 1;
            StringBuilder sb = new StringBuilder();
            sb.Append("2@3");
            long number = 3;
            int currentCount;
            String fileName;
            double limit;
            Boolean add = true;
            while (this.Primes.Count < this.Limit)
            {
                currentCount = this.Primes.Count;
                number = this.Primes[currentCount - 1];
                do
                {
                    number += 2;
                    limit = Math.Sqrt(number);
                    //Check if is divisible by other numbers
                    foreach (long prime in this.Primes)
                    {
                        if (number % prime == 0)
                        {
                            add = false;
                            break;
                        }
                        if (prime > limit)
                            break;
                    }
                    //Add if is prime
                    if (add)
                    {
                        try
                        {
                            if (number < block * BLOCK_SIZE)
                                sb.Append("@" + number);
                            else
                            {
                                fileName = (BLOCK_SIZE * 500 * fileIndex).ToString() + ".txt";
                                if (!File.Exists(Path.Combine(file.Directory.FullName, fileName)))
                                    File.Create(Path.Combine(file.Directory.FullName, fileName)).Close();
                                using (StreamWriter w = File.AppendText(Path.Combine(file.Directory.FullName, fileName)))
                                    w.Write("[" + block * BLOCK_SIZE + "]" + sb.ToString() + "\n");
                                blockCount++;
                                if (blockCount == 500)
                                {
                                    fileIndex++;
                                    blockCount = 0;
                                }
                                sb = new StringBuilder();
                                sb.Append(number);
                                block++;
                            }
                        }
                        catch (Exception)
                        {

                        }
                        this.Primes.Add(number);
                    }
                    add = true;

                } while (currentCount == this.Primes.Count);
            }
        }



        public Dictionary<long, List<long>> CreateBlocks(long limit, long blockSize)
        {
            Dictionary<long, List<long>> BlockPrimes = new Dictionary<long, List<long>>();
            long Vector = limit / blockSize, block = 1, key;
            for (int i = 0; i < this.Primes.Count; i++)
            {
                if (this.Primes[i] > block * Vector)
                    block++;
                key = block * Vector;

                if (!BlockPrimes.ContainsKey(key))
                    BlockPrimes.Add(key, new List<long>());
                BlockPrimes[key].Add(this.Primes[i]);
            }
            return BlockPrimes;
        }

        public long GetKey(long num, long limit, long blockSize)
        {
            long Vector = limit / blockSize;
            return ((long)(num / Vector) + 1) * Vector;
        }
    }
}
