using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    /// Multiples of 3 and 5
    /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    /// Find the sum of all the multiples of 3 or 5 below 1000.
    /// </summary>
    public class MultiplesOf3Or5 : ISolution
    {
        /// <summary>
        /// The first multiple
        /// </summary>
        public const int N1 = 3;
        /// <summary>
        /// The second multiple
        /// </summary>
        public const int N2 = 5;
        /// <summary>
        /// The request limit
        /// </summary>
        public int Limit;

        public int Result;


        public MultiplesOf3Or5(int limit)
        {
            this.Limit = limit;
            this.Result = this.Solve();
        }

        /// <summary>
        /// Prints the result
        /// </summary>
        /// <returns>The result</returns>
        public string PrintResult()
        {
            return string.Format("The sum of all multiples of {0}, or {1} below {2} is {3}", N1, N2, Limit, Result);
        }

        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The problem result</returns>
        public int Solve()
        {
            int i = N1;
            int j = N2;
            int sum = 0;
            try
            {
                do
                {
                    sum += i;
                    i += 3;
                    if (j < this.Limit)
                    {
                        if (j % 3 != 0)
                            sum += j;
                        j += 5;
                    }
                } while (i < this.Limit);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return sum;
        }
    }
}