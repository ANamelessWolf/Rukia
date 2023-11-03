using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Helper
{
    public class StringNumber
    {
        String[] units = new String[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        String[] tens = new String[] { "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        String[] specials = new String[] { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        String[] suffix = new String[] { "hundred", "thousand", "million", "billion" };

        public long Number { get; }
        public string EnglishName { get; }

        private readonly Dictionary<long, string> Conversion;

        public StringNumber(long number)
        {
            this.Number = number;
            this.Conversion = new Dictionary<long, string>();
            this.Conversion.Add(0, "zero");
            //Units
            for (int i = 1; i <= 9; i++)
                this.Conversion.Add(i, units[i - 1]);
            //Specials
            for (int i = 11; i <= 19; i++)
                this.Conversion.Add(i, specials[i - 11]);
            //Tens
            for (int i = 10; i <= 90; i += 10)
                this.Conversion.Add(i, tens[i / 10 - 1]);
            //Suffix
            this.Conversion.Add(TenPower(2), suffix[0]);
            this.Conversion.Add(TenPower(3), suffix[1]);
            this.Conversion.Add(TenPower(6), suffix[2]);
            this.Conversion.Add(TenPower(9), suffix[3]);
            //Convert
            this.EnglishName = this.ToStringNumber(this.Number);
        }

        private string ToStringNumber(long n)
        {
            string value = "";

            if (n < TenPower(2) && this.Conversion.ContainsKey(n))
                return this.Conversion[n];
            if (n > TenPower(9) && n < TenPower(12))
            {
                var prefix = n / TenPower(9);
                value += $"{this.GetPrefix(prefix)} {suffix[3]}";
                if (prefix >= 100)
                    value = value.Replace("-", " ");
                n = n % TenPower(9);
            }
            if (n == TenPower(9))
                value = "one " + suffix[3];
            if (n > TenPower(6) && n < TenPower(9))
            {
                if (value.Length > 0)
                    value += ", ";
                var prefix = n / TenPower(6);
                value += $"{this.GetPrefix(prefix)} {suffix[2]}";
                if (prefix >= 100)
                    value = value.Replace("-", " ");
                n = n % TenPower(6);
            }
            if (n == TenPower(6))
                value = "one " + suffix[2];
            if (n > TenPower(3) && n < TenPower(6))
            {
                if (value.Length > 0)
                    value += ", ";
                var prefix = n / TenPower(3);
                value += $"{this.GetPrefix(prefix)} {suffix[1]}";
                if (prefix >= 100)
                    value = value.Replace("-", " ");
                n = n % TenPower(3);
            }
            if (n == TenPower(3))
                value = "one " + suffix[1];
            if (n > 0 && n < TenPower(3))
            {
                if (value.Length > 0)
                    value += n >= 100 ? ", " : " and ";
                value += this.GetPrefix(n);
            }



            return value;
        }

        private string GetPrefix(long prefix)
        {
            string value = "";
            //Hundreds
            if (prefix / 100 > 0)
            {
                value = $"{this.Conversion[prefix / 100]} {suffix[0]}";
                prefix = prefix % 100;
            }
            // Specials
            if (prefix > 10 && prefix < 20)
            {
                if (value.Length > 0)
                    value += " and ";
                value += this.Conversion[prefix];
                prefix = 0;
            }

            // Tens
            if (prefix / 10 > 0)
            {
                value = format(value, prefix - prefix % 10);
                prefix = prefix % 10;
                if (prefix > 0)
                    value = format(value, prefix);
            }
            else if (prefix / 10 == 0 && prefix % 10 > 0)
            {
                if (value.Length > 0)
                    value = value + " and " + this.Conversion[prefix % 10];
                else
                    value = this.Conversion[prefix % 10];
            }

            return value;

        }

        private long TenPower(int exponent)
        {
            long number = 1;
            for (int i = 1; i <= exponent; i++)
                number *= 10;
            return number;

        }

        private string format(string value, long number)
        {
            if (number < 10)
                return value.Length > 0 ? value + "-" + this.Conversion[number] : this.Conversion[number];
            return value.Length > 0 ? value + " and " + this.Conversion[number] : this.Conversion[number];
        }
    }
}
