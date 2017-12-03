using Nameless.Libraries.Rukia.ProjectEuler.Poker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler
{
    /// <summary>
    /// In the card game poker, a hand consists of five cards and are ranked, from lowest to highest, in the following way:
    /// High Card: Highest value card.
    /// One Pair: Two cards of the same value.
    /// Two Pairs: Two different pairs.
    /// Three of a Kind: Three cards of the same value.
    /// Straight: All cards are consecutive values.
    /// Flush: All cards of the same suit.
    /// Full House: Three of a kind and a pair.
    /// Four of a Kind: Four cards of the same value.
    /// Straight Flush: All cards are consecutive values of same suit.
    /// Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.
    /// The cards are valued in the order:
    /// 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, Ace.
    /// If two players have the same ranked hands then the rank made up of the highest value wins; 
    /// for example, a pair of eights beats a pair of fives (see example 1 below). 
    /// But if two ranks tie, for example, both players have a pair of queens, then highest cards in each hand are compared (see example 4 below);
    /// if the highest cards tie then the next highest cards are compared, and so on.
    /// Consider the following five hands dealt to two players:
    /// Hand	 	Player 1	 	Player 2	 	Winner
    /// 1	 	5H 5C 6S 7S KD   2C 3S 8S 8D TD     Player 2
    ///         Pair of Fives    Pair of Eights
    /// 2	 	5D 8C 9S JS AC   2C 5C 7D 8S QH     Player 1
    ///         Highest card Ace Highest card Queen
    /// 3	 	2D 9C AS AH AC   3D 6D 7D TD QD     Player 2
    ///         Three Aces       Flush with Diamonds
    /// 4	 	4D 6S 9H QH QC   3D 6D 7H QD QS     Player 1
    ///         Pair of Queens   Pair of Queens
    ///       Highest card Nine Highest card Seven
    /// 5	 	2H 2D 4C 4D 4S   3C 3D 3S 9S 9D     Player 1
    ///         Full House      With Three Fours
    /// The file, resource p054_poker, contains one-thousand random hands dealt to two players. 
    /// Each line of the file contains ten cards (separated by a single space): the first five are Player 1's cards and the last five are Player 2's cards. 
    /// You can assume that all hands are valid (no invalid characters or repeated cards), each player's hand is in no specific order, and in each hand there is a clear winner.
    /// How many hands does Player 1 win?
    /// </summary>
    public class PokerHands
    {
        List<PokerHand> Player1, Player2;
        /// <summary>
        /// The factorial result
        /// </summary>
        public int Player1Victories { get { return Solve(); } }
        /// <summary>
        /// Calculate all the poker games
        /// </summary>
        public PokerHands()
        {
            this.Player1 = new List<PokerHand>();
            this.Player2 = new List<PokerHand>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Generando partidas...");
            InitHands();
            sw.Stop();
            Console.WriteLine("Elapsed:{2}min {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds, sw.Elapsed.Minutes);
        }
        public void InitHands()
        {
            String[] lines = Resources.Resources.p054_poker.Split('\n');
            String hand1, hand2;
            for (int i = 0; i < lines.Length - 1; i++)
            {
                hand1 = lines[i].Substring(0, 14);
                hand2 = lines[i].Substring(15, 14);
                this.Player1.Add(PokerHand.Parse(hand1));
                this.Player2.Add(PokerHand.Parse(hand2));
            }
        }
        /// <summary>
        /// Solve the problem
        /// </summary>
        /// <returns>The sum result</returns>
        private int Solve()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Jugando...");
            int p1Counts = 0;
            for (int i = 0; i < this.Player1.Count; i++)
            {
                if (this.Player1[i].GameResult(this.Player2[i]))
                    p1Counts++;
            }
            sw.Stop();
            Console.WriteLine("Elapsed: {0}s, {1}ms", sw.Elapsed.Seconds, sw.Elapsed.Milliseconds);
            return p1Counts;
        }

        /// <summary>
        /// Print the result
        /// </summary>
        /// <returns>The result</returns>
        public override string ToString()
        {
            return String.Format("The Player 1 win {0} times", this.Player1Victories);
        }
    }
}
