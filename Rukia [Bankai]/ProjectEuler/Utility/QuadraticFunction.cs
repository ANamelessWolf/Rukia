using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class QuadraticFunction
    {
        /// <summary>
        /// The first coeficient of the quadratic function
        /// </summary>
        public double A;
        /// <summary>
        /// The second coeficient of the quadratic function
        /// </summary>
        public double B;
        /// <summary>
        /// The third coeficient of the quadratic function
        /// </summary>
        public double C;
        /// <summary>
        /// The first quadratic root value
        /// </summary>
        public double X1;
        /// <summary>
        /// The second quadratic root value
        /// </summary>
        public double X2;
        /// <summary>
        /// Creates a new quadratic function
        /// </summary>
        /// <param name="a">The first coeficient of the quadratic function</param>
        /// <param name="b">The second coeficient of the quadratic function</param>
        /// <param name="c">The third coeficient of the quadratic function</param>
        public QuadraticFunction(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            double discriminant = (b * b) - (4 * a * c);
            if (discriminant < 0)
            {
                this.X1 = double.NaN;
                this.X1 = double.NaN;
                this.X2 = (-b + Math.Sqrt(discriminant)) / 2 * a;
            }
            else
            {
                this.X1 = (-b + Math.Sqrt(discriminant)) / 2 * a;
                if (discriminant == 0)
                    this.X2 = this.X1;
                else
                    this.X2 = (-b - Math.Sqrt(discriminant)) / 2 * a;
            }
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{0}x²");
            if (this.B < 0)
                sb.Append("{1}x²");
            else
                sb.Append("+ {1}x");
            if (this.C < 0)
                sb.Append("{2}");
            else
                sb.Append("+ {2}");
            sb.Append(" = 0; X1:{3}, X2:{4}");
            return String.Format(sb.ToString(), this.A, this.B, this.C, this.X1, this.X2);
        }
    }
}
