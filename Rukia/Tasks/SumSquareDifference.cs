using Nameless.Libraries.Rukia.ProjectEuler.Helper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Tasks
{
    /// <summary>
    /// The sum of the squares of the first ten natural numbers is,
    /// 12 + 22 + ... + 102 = 385
    /// The square of the sum of the first ten natural numbers is,
    /// (1 + 2 + ... + 10)2 = 552 = 3025
    /// Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    /// Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    /// </summary>
    public class SumSquareDifference : ISolution
    {
        public int Limit { get; }
        public int Result { get; }

        public SumSquareDifference(int limit) 
        { 
            this.Limit = limit;
            this.Result = this.Solve();
        }


        public string PrintResult()
        {
            return String.Format("The difference between the sum of the squares of the first {0} natural numbers and the square of the sum is {1}", this.Limit, this.Result);
        }

        public int Solve()
        {
            //The sum of squares is
            //1²+2²+...n²
            //The square of the sum is
            //(1+2+...n)²
            //And also can be written as
            //1²+1*(2+3+..n)+2²+2*(1+3+...n)+...n²+n*(1+2+3+...n-1)
            //So the sum square difference can be written as 
            //1*(2+3+..n)+2*(1+3+...n)+...n*(1+2+3+...n-1)

            int result = 0;
            //First we obtain the sum from 1 to n
            int sum = 0;
            for (int i = 1; i <= this.Limit; i++)
                sum += i;
            //Then we calculate the difference
            for (int i = 1; i <= this.Limit; i++)
                result += i * (sum - i);
            return result;
        }
    }
}
