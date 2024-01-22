using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utils
{
    public class AbundantNumberGenerator
    {
        public List<int> Numbers { get; }
        private int TestNumber { get; set; }
        public PrimeTester Tester { get; }

        public AbundantNumberGenerator(int start)
        {
            Numbers = new List<int>();
            TestNumber = start;
            Tester = new PrimeTester();
        }

        public void Next()
        {
            bool isAbundant = false;
            while (!isAbundant)
            {
                if (TestNumber == 1 || Tester.IsPrime(TestNumber))
                    TestNumber++;
                else
                {
                    isAbundant = TestNumber.IsAbundant(Tester);
                    if (isAbundant)
                    {
                        Numbers.Add(TestNumber);
                    }
                    TestNumber++;
                }
            }
        }

        public int? Last()
        {
            return Numbers.Count == 0 ? null : Numbers.Last();
        }


    }
}
