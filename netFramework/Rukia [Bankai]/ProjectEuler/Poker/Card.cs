using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Poker
{
    public class Card : IComparable<Card>
    {
        /// <summary>
        /// Return the poker in parse string format
        /// </summary>
        public String ToParseString
        {
            get
            {
                if (this.Value == CardValue.Joker)
                    return "JJ";
                StringBuilder sb = new StringBuilder();
                switch (Suit)
                {
                    case CardSuit.Clubs:
                        sb.Append('C');
                        break;
                    case CardSuit.Diamonds:
                        sb.Append('D');
                        break;
                    case CardSuit.Hearts:
                        sb.Append('H');
                        break;
                    case CardSuit.Spades:
                        sb.Append('S');
                        break;
                }
                switch (Value)
                {
                    case CardValue.Ace:
                        sb.Append('A');
                        break;
                    case CardValue.Jack:
                        sb.Append('J');
                        break;
                    case CardValue.King:
                        sb.Append('K');
                        break;
                    case CardValue.Queen:
                        sb.Append('Q');
                        break;
                    case CardValue.Ten:
                        sb.Append('T');
                        break;
                    default :
                        sb.Append((int)Value);
                        break;
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// The card value
        /// </summary>
        public CardValue Value;
        /// <summary>
        /// The card suite
        /// </summary>
        public CardSuit Suit;
        /// <summary>
        /// Creates a new card value
        /// </summary>
        /// <param name="value">The card value</param>
        /// <param name="suit">The suite value</param>
        public Card(CardValue value, CardSuit suit)
        {
            if (value == CardValue.Joker || suit == CardSuit.Joker)
            {
                this.Value = CardValue.Joker;
                this.Suit = CardSuit.Joker;
            }
            else
            {
                this.Value = value;
     
                this.Suit = suit;
            }
        }
        /// <summary>
        /// Parse a card value
        /// </summary>
        /// <param name="cardString">The card string to parse</param>
        /// <returns>The card value parsed</returns>
        public static Card Parse(String cardString)
        {
            Char[] card = cardString.ToCharArray();
            if (card.Length == 2)
            {
                CardValue value;
                CardSuit suit;
                switch (card[0])
                {
                    case 'A':
                        value = CardValue.Ace;
                        break;
                    case 'T':
                        value = CardValue.Ten;
                        break;
                    case 'J':
                        value = CardValue.Jack;
                        break;
                    case 'Q':
                        value = CardValue.Queen;
                        break;
                    case 'K':
                        value = CardValue.King;
                        break;
                    default:
                        int val;
                        if (int.TryParse(card[0].ToString(), out val))
                            value = (CardValue)val;
                        else
                            value = CardValue.Joker;
                        break;
                }
                switch (card[1])
                {
                    case 'C':
                        suit = CardSuit.Clubs;
                        break;
                    case 'H':
                        suit = CardSuit.Hearts;
                        break;
                    case 'D':
                        suit = CardSuit.Diamonds;
                        break;
                    case 'S':
                        suit = CardSuit.Spades;
                        break;
                    default:
                        suit = CardSuit.Joker;
                        break;
                }
                return new Card(value, suit);
            }
            else
                return new Card(CardValue.Joker, CardSuit.Joker);
        }


        /// <summary>
        /// Evaluates the less or equal than operator
        /// </summary>
        /// <param name="a">The first card to compare</param>
        /// <param name="b">The second card to compare</param>
        /// <returns>True if cards are equals</returns>
        public static Boolean operator <(Card a, Card b)
        {
            if (a.Value == b.Value)
                return false;
            else
                return (int)a.Value < (int)b.Value;
        }
        /// <summary>
        /// Evaluates the greater than operator
        /// </summary>
        /// <param name="a">The first card to compare</param>
        /// <param name="b">The second card to compare</param>
        /// <returns>True if cards are equals</returns>
        public static Boolean operator >(Card a, Card b)
        {
            if (a.Value == b.Value)
                return false;
            else
                return (int)a.Value > (int)b.Value;
        }
        /// <summary>
        /// Compare the values between cards
        /// </summary>
        /// <param name="other">The other card to compare</param>
        /// <returns>The compare card</returns>
        public int CompareTo(Card other)
        {
            if (this.Value == other.Value && this.Suit == other.Suit)
                return 0;
            else
            {
                if (this.Value == other.Value)
                {
                    if ((int)this.Suit > (int)other.Suit)
                        return 1;
                    else
                        return -1;
                }
                else
                {
                    if ((int)this.Value > (int)other.Value)
                        return 1;
                    else
                        return -1;
                }
            }
        }
        /// <summary>
        /// The card string value
        /// </summary>
        /// <returns>The card value</returns>
        public override string ToString()
        {
            if (this.Value == CardValue.Joker)
                return "J";
            StringBuilder sb = new StringBuilder();
            switch (Suit)
            {
                case CardSuit.Clubs:
                    sb.Append('♣');
                    break;
                case CardSuit.Diamonds:
                    sb.Append('♦');
                    break;
                case CardSuit.Hearts:
                    sb.Append('♥');
                    break;
                case CardSuit.Spades:
                    sb.Append('♠');
                    break;
            }
            sb.Append('(');
            switch (Value)
            {
                case CardValue.Ace:
                    sb.Append('A');
                    break;
                case CardValue.Jack:
                    sb.Append('J');
                    break;
                case CardValue.King:
                    sb.Append('K');
                    break;
                case CardValue.Queen:
                    sb.Append('Q');
                    break;
                default:
                    sb.Append((int)Value);
                    break;
            }
            sb.Append(')');
            return sb.ToString();
        }





        internal char ToParseCardValue()
        {
            return this.ToParseString[1];
        }
    }
}
