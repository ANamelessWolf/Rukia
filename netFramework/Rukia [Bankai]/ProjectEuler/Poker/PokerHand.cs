using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Poker
{
    public class PokerHand
    {
        /// <summary>
        /// The available cards
        /// </summary>
        public Card[] Cards;
        /// <summary>
        /// Get the HighestCard
        /// </summary>
        public Card HighestCard { get { return Cards[4]; } }
        /// <summary>
        /// Get the HighestCard
        /// </summary>
        public Boolean HasFlush { get { CardSuit suit = Cards[0].Suit; return Cards.Count<Card>(X => X.Suit == suit) == 5; } }
        /// <summary>
        /// Check if the hand has straight
        /// </summary>
        public Boolean HasStraight { get { return "A123456789TJQKA".Contains(CardValueString); } }
        /// <summary>
        /// Get the Flush Suite color
        /// </summary>
        public CardSuit FlushSuite { get { return HasFlush ? Cards[0].Suit : CardSuit.Joker; } }


        CardValue PokerCard, Tertia;
        Card[] Pairs;
        CardValue[] FullHouse;
        /// <summary>
        /// The card value string
        /// </summary>
        public String CardValueString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (Card c in Cards)
                    sb.Append(c.ToParseCardValue());
                if (sb.ToString() == "1234A")
                    return "A1234";
                else
                    return sb.ToString();
            }
        }

        /// <summary>
        /// Current Hand
        /// </summary>
        public PokerRules Hand;
        /// <summary>
        /// Creates a new poker hand
        /// </summary>
        /// <param name="c1">First card</param>
        /// <param name="c2">Second card</param>
        /// <param name="c3">Third card</param>
        /// <param name="c4">Fourth card</param>
        /// <param name="c5">Fifth card</param>
        public PokerHand(Card c1, Card c2, Card c3, Card c4, Card c5)
        {
            List<Card> cs = new List<Card>();
            cs.Add(c1);
            cs.Add(c2);
            cs.Add(c3);
            cs.Add(c4);
            cs.Add(c5);
            cs.Sort();
            this.Cards = cs.ToArray();
            this.ValidateHand();
        }
        /// <summary>
        /// Get the game result true if the player wins
        /// false if loose
        /// </summary>
        /// <param name="otherHand">The other player hand</param>
        /// <returns>The game result</returns>
        public Boolean GameResult(PokerHand otherHand)
        {

            if ((int)this.Hand > (int)otherHand.Hand)
                return true;
            else if ((int)this.Hand < (int)otherHand.Hand)
                return false;
            else
            {
                Boolean flag;
                switch (this.Hand)
                {
                    case PokerRules.Straight:
                    case PokerRules.Straight_Flush:
                    case PokerRules.Flush:
                    case PokerRules.High_Card:
                        if (this.HighestCard > otherHand.HighestCard)
                            flag = true;
                        else
                            flag = false;
                        break;
                    case PokerRules.One_Pair:
                        if (this.Pairs[0] > otherHand.Pairs[0])
                            flag = true;
                        else if (this.Pairs[0] < otherHand.Pairs[0])
                            flag = false;
                        else
                        {
                            if (this.HighestCard > otherHand.HighestCard)
                                flag = true;
                            else
                                flag = false;
                        }
                        break;
                    case PokerRules.Two_Pairs:
                        Card c1 = this.Pairs[0] > this.Pairs[1] ? this.Pairs[0] : this.Pairs[1];
                        Card c2 = otherHand.Pairs[0] > otherHand.Pairs[1] ? otherHand.Pairs[0] : otherHand.Pairs[1];
                        if (c1 > c2)
                            flag = true;
                        else if (c1 < c2)
                            flag = false;
                        else
                        {
                            c1 = this.Pairs[0] > this.Pairs[1] ? this.Pairs[1] : this.Pairs[0];
                            c2 = otherHand.Pairs[0] > otherHand.Pairs[1] ? otherHand.Pairs[1] : otherHand.Pairs[0];
                            if (c1 > c2)
                                flag = true;
                            else if (c1 < c2)
                                flag = false;
                            else
                            {
                                if (this.HighestCard > otherHand.HighestCard)
                                    flag = true;
                                else
                                    flag = false;
                            }
                        }
                        break;
                    case PokerRules.Full_House:
                    case PokerRules.Three_of_a_Kind:
                        flag = this.Tertia > otherHand.Tertia;
                        break;
                    case PokerRules.Poker:
                        flag = this.PokerCard > otherHand.PokerCard;
                        break;
                    default:
                        if ((int)this.FlushSuite > (int)otherHand.FlushSuite)
                            flag = true;
                        else
                            flag = false;
                        break;
                }
                return flag;
            }
        }

        /// <summary>
        /// Parse a poker Hand
        /// </summary>
        /// <param name="handString">The poker hand in string format</param>
        /// <returns>The poker hand</returns>
        public static PokerHand Parse(String handString)
        {
            String[] cards = handString.Split(' ');
            Card[] pCards = new Card[5];
            int index = 0;
            foreach (String card in cards)
            {
                if (card != String.Empty)
                {
                    pCards[index] = Card.Parse(card);
                    index++;
                }
            }
            return new PokerHand(pCards[0], pCards[1], pCards[2], pCards[3], pCards[4]);
        }
        /// <summary>
        /// Validate the current hand
        /// </summary>
        private void ValidateHand()
        {
            if (HasFlush)
            {
                //Can be Flush, Straight Flush o Royal Flush
                if (HasStraight)
                {
                    if (this.CardValueString == "TJQKA")
                        this.Hand = PokerRules.Royal_Flush;
                    else
                        this.Hand = PokerRules.Straight_Flush;
                }
                else
                    this.Hand = PokerRules.Flush;
            }
            else
            {
                Dictionary<Card, int> countCards = new Dictionary<Card, int>();
                foreach (Card c in Cards)

                    if (!ContainsCardValue(countCards, c))
                        countCards.Add(c, 1);
                    else
                        AddCount(countCards, c);
                try { PokerCard = countCards.Where<KeyValuePair<Card, int>>(X => X.Value == 4).FirstOrDefault().Key.Value; }
                catch (Exception) { PokerCard = CardValue.Joker; }

                try { Tertia = countCards.Where<KeyValuePair<Card, int>>(X => X.Value == 3).FirstOrDefault().Key.Value; }
                catch (Exception) { Tertia = CardValue.Joker; }
                Pairs = countCards.Where<KeyValuePair<Card, int>>(X => X.Value == 2).Select<KeyValuePair<Card, int>, Card>(X => X.Key).ToArray();

                if (PokerCard != CardValue.Joker)
                    this.Hand = PokerRules.Poker;
                else if (Tertia != CardValue.Joker && Pairs.Length == 1)
                {
                    this.Hand = PokerRules.Full_House;
                    this.FullHouse = new CardValue[] { Tertia, Pairs[0].Value };
                }
                else if (Tertia != CardValue.Joker && Pairs.Length == 0)
                    this.Hand = PokerRules.Three_of_a_Kind;
                else if (Pairs.Length == 1)
                    this.Hand = PokerRules.One_Pair;
                else if (Pairs.Length == 2)
                    this.Hand = PokerRules.Two_Pairs;
                else
                {
                    if (HasStraight)
                        this.Hand = PokerRules.Straight;
                    else
                        this.Hand = PokerRules.High_Card;
                }
            }

        }

        private void AddCount(Dictionary<Card, int> countCards, Card card)
        {
            Card[] cards = countCards.Keys.ToArray();
            foreach (Card key in cards)
                if (key.Value == card.Value)
                    countCards[key] += 1;
        }

        private bool ContainsCardValue(Dictionary<Card, int> countCards, Card card)
        {
            foreach (Card key in countCards.Keys)
                if (key.Value == card.Value)
                    return true;
            return false;
        }
        /// <summary>
        ///Get the poker hand string
        /// </summary>
        /// <returns>The poker hand string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Card c in Cards)
                sb.Append(c + ", ");
            sb.Remove(sb.Length - 2, 2);
            sb.Append(" Hand: " + Hand.ToString());
            return sb.ToString();
        }
    }
}
