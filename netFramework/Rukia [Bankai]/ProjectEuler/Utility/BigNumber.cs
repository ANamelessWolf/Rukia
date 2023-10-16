using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Utility
{
    public class BigNumber
    {
        public int size;

        public List<long> Digits;

        public BigNumber(int size = 10)
        {
            this.Digits = new List<long>();
            this.size = size;
        }

        public static BigNumber Parse(String numString, int size = 10)
        {
            BigNumber bNum = new BigNumber();
            String subNum;
            while (numString != String.Empty)
            {
                if (numString.Length - 1 >= 10)
                    subNum = numString.Substring(numString.Length - size);
                else
                    subNum = numString;
                bNum.Digits.Add(long.Parse(subNum));
                numString = numString.Replace(subNum, String.Empty);
            }
            return bNum;
        }

        public static BigNumber operator +(BigNumber num1, BigNumber num2)
        {
            BigNumber result = new BigNumber(),
                          n1 = BigNumber.Copy(num1),
                          n2 = BigNumber.Copy(num2);
            long maxSize = (long)Math.Pow(n1.size, 10), carry = 0, sum;
            //Se realiza el formateo de la suma para sumar digito por digito
            int maxDigitCount = n1.Digits.Count > n2.Digits.Count ? n1.Digits.Count : n2.Digits.Count;

            while (n1.Digits.Count < maxDigitCount)
                n1.Digits.Add(0);
            while (n2.Digits.Count < maxDigitCount)
                n2.Digits.Add(0);

            //Realizamos la suma digito a digito
            for (int dIndex = 0; dIndex < n1.Digits.Count; dIndex++)
            {
                sum = n1.Digits[dIndex] + n2.Digits[dIndex];
                sum += carry;
                if (sum > maxSize)
                {
                    carry = 1;
                    sum = sum - maxSize;
                }
                else
                    carry = 0;
                result.Digits.Add(sum);
            }
            //Revisamos el valor del carry para ver si lo agregamos a la suma
            if (carry != 0)
                result.Digits.Add(carry);
            return result;
        }


        public static BigNumber operator *(BigNumber num1, BigNumber num2)
        {
            BigNumber result = new BigNumber(),
                n1 = BigNumber.Copy(num1),
                n2 = BigNumber.Copy(num2);
            Decimal maxSize = (Decimal)Math.Pow(n1.size, 10), carry = 0;
            //Llenamos los operandos de la multiplicación
            BigNumber[] mOperands = new BigNumber[n2.Digits.Count];
            Decimal mul;
            //Multiplicando con el algoritmo de "Grid method multiplication"
            for (int n2Row = 0; n2Row < n2.Digits.Count; n2Row++)
            {
                mOperands[n2Row] = new BigNumber();
                //Se acomodan las filas de la multiplicación agregando ceros a la derecha
                for (int i = 0; i < n2Row; i++)
                    mOperands[n2Row].Digits.Add(0);
                for (int n1Row = 0; n1Row < n1.Digits.Count; n1Row++)
                {
                    if ((mOperands[n2Row].Digits.Count + n2Row) < (n1Row + 1))
                        mOperands[n2Row].Digits.Add(0);
                    //Realizamos la multiplicación por digitos
                    mul = Decimal.Multiply(n1.Digits[n1Row], n2.Digits[n2Row]);
                    mul += carry;
                    //Calculamos el accarreo para el siguiente número
                    if (mul > maxSize)
                    {
                        carry = mul - (mul - maxSize);
                        mul = mul - maxSize;
                    }
                    else
                        carry = 0;
                    mOperands[n2Row].Digits[n1Row] = (long)mul;
                }
            }

            if (mOperands.Length == 1)
                result = mOperands[0];
            else
            {
                for (int i = 0; i < mOperands.Length; i++)
                    result = result + mOperands[i];
            }
            return result;

        }

        private static BigNumber Copy(BigNumber number)
        {
            return Parse(number.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            String formatted;
            for (int i = this.Digits.Count - 1; i >= 0; i--)
            {

                formatted = this.Digits[i].ToString();
                if (i != this.Digits.Count - 1)
                {
                    while (formatted.Length != this.size)
                        formatted = "0" + formatted;
                }
                sb.Append(formatted);
            }
            return sb.ToString();
        }

    }
}
