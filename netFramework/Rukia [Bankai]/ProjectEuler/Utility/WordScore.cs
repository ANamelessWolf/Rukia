using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class WordScore
    {
        const String ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        /// <summary>
        /// The name
        /// </summary>
        public String Name;
        /// <summary>
        /// The position of the name
        /// </summary>
        public int Position;
        /// <summary>
        /// The name value
        /// </summary>
        public int NameValue;
        /// <summary>
        /// Check if the NameValue is a triangle number
        /// tn = ½n(n+1)
        /// tn: Name Value
        /// </summary>
        /// <returns>True if the name value is a triangle number</returns>
        public Boolean IsTriangleWord
        {
            get
            {
                Boolean flag = false;
                // n²+n-2tn =0;
                QuadraticFunction qF = new QuadraticFunction(1, 1, (-2 * this.NameValue));
                double root = qF.X1 > qF.X2 ? qF.X1 : qF.X2;
                flag = root % 1 == 0d;
                return flag;
            }
        }

        /// <summary>
        /// The Score value
        /// </summary>
        public int Score { get { return Position * NameValue; } }
        /// <summary>
        /// Get the name an format it
        /// </summary>
        /// <param name="name">Name score</param>
        /// <param name="index">The name index</param>
        public WordScore(String name, int index)
        {
            this.Name = name.Replace("\"", "");
            this.NameValue = GetWorth(this.Name);
            this.Position = index;
        }
        /// <summary>
        /// Get the value of the name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The name value</returns>
        private int GetWorth(string name)
        {
            int sum = 0;
            foreach (Char letter in name)
                sum += ABC.IndexOf(letter) + 1;
            return sum;
        }
        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("{0}({1}), Score: {2}", this.Name, this.Position, this.Score);
        }
    }
}
