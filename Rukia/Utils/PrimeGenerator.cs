using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utils
{
    public class PrimeGenerator
    {
        const int ROW_MAX = 1000;
        const string FILE_NAME = @"Primes.txt";

        public PrimeGenerator()
        {

        }

        public List<long> getPrimes(long min, long max)
        {
            int start = (int)min / 1000;
            int end = ((int)max / 1000) + 1;
            List<long> primes = new List<long>();
            //Seleccionamos las líneas del archivo
            IEnumerable<string> lines = File.ReadLines(FILE_NAME).Skip(start).Take(end);
            foreach (string line in lines)
            {
               var p = line.Split(',')
                    .Select(x => long.Parse(x))
                    .Where(x => x >= min && x <= max);
                primes.AddRange(p);
            }
            return primes;
        }

        public void Create(long limit = 2000000)
        {
            string path = FILE_NAME;
            //1: Delete old file if exists
            if (File.Exists(path))
                File.Delete(path);
            //2: WriteLine
            using (StreamWriter sw = File.CreateText(path))
                sw.Write("2,3,5,7,11");

            //3: Generate primes file
            long number = 13;
            PrimeTester tester = new PrimeTester();
            bool newLine = false;
            while (number <= limit)
            {
                if (tester.IsPrime(number))
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        if (newLine)
                        {
                            sw.Write(number.ToString());
                            newLine = false;
                        }
                        else
                            sw.Write("," + number.ToString());
                    }
                }
                else if (number % 1000 == 0)
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("");
                        newLine = true;
                    }
                }
                number++;
            }
        }

    }
}
