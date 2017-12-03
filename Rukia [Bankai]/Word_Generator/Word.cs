using Nameless.Libraries.Evangelion.Rei;
using Nameless.Libraries.Rukia.DictionaryWebService;
using Nameless.Libraries.Yggdrasil.Lilith;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.Word_Generator
{
    public class Word : NamelessObject
    {
        String Value;
        /// <summary>
        /// Get the word definitions
        /// </summary>
        public Definition[] Meaning;
        /// <summary>
        /// Validates if the word has any meanings
        /// </summary>
        /// <returns>True if the word has any meaning</returns>
        public Boolean HasMeaning
        {
            get { return this.Meaning.Length > 0; }
        }
        /// <summary>
        /// Creates a word from a collection of characters ordered by the character indexes
        /// </summary>
        /// <example>
        /// An array of characters { 'S','U','E','H','O' } with indexes { 3,2,4,0,1 } generates the
        /// word HOUSE
        /// </example>
        /// <param name="langle">Tha language manager</param>
        /// <param name="charIndex">The array of character indexes</param>
        /// <param name="characters">The array of characters</param>
        public Word(byte[] charIndex, char[] characters)
        {
            Value = String.Empty;
            Meaning = new Definition[0];
            for (int i = 0; i < charIndex.Length; i++)
                Value += characters[charIndex[i]];
        }
        /// <summary>
        /// Get the word definition from a web service, internet connection is
        /// needed
        /// </summary>
        public void GetMeaning()
        {
            DictServiceSoapClient dictionary = new DictServiceSoapClient("DictServiceSoap");
            WordDefinition wordDefinition = dictionary.Define(this.Value);
            this.Meaning = wordDefinition.Definitions;
        }
        /// <summary>
        /// Check if the word has repeated indexes
        /// </summary>
        /// <param name="indexes">The array of indexes</param>
        /// <returns>True if the word has repeated indexes</returns>
        public bool CheckRepetition(byte[] indexes)
        {
            int i, j;
            byte baseNum = (byte)this.Value.ToString().Length;
            IntegerNumber num = new IntegerNumber(baseNum);
            num.Digits.Add(0);
            Boolean flag = false;
            for (int k = 0; k < baseNum * baseNum; k++)
            {
                i = num.Digits[0];
                j = num.Digits[1];
                if (i != j)
                {
                    flag = flag || (indexes[i] == indexes[j]);
                    if (flag)
                        break;
                }
                num.Next();
            }
            return flag;
        }

        /// <summary>
        ///  Gets the word string
        /// </summary>
        /// <returns>The word string</returns>
        public override string ToString()
        {
            return this.Value;
        }




    }
}
