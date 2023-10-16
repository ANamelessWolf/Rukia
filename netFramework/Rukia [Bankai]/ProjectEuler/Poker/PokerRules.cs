using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nameless.Libraries.Rukia.ProjectEuler.Poker
{
    public enum PokerRules
    {
        /// <summary>
        /// Highest value card.
        /// </summary>
        High_Card = 1,
        /// <summary>
        /// Two cards of the same value.
        /// </summary>
        One_Pair = 2,
        /// <summary>
        /// Two different pairs.
        /// </summary>
        Two_Pairs = 3,
        /// <summary>
        /// Three cards of the same value
        /// </summary>
        Three_of_a_Kind = 4,
        /// <summary>
        /// All cards are consecutive values
        /// </summary>
        Straight = 5,
        /// <summary>
        /// All cards of the same suit.
        /// </summary>
        Flush = 6,
        /// <summary>
        /// Three of a kind and a pair
        /// </summary>
        Full_House = 7,
        /// <summary>
        /// Four cards of the same value.
        /// </summary>
        Poker = 8,
        /// <summary>
        /// All cards are consecutive values of same suit.
        /// </summary>
        Straight_Flush = 9,
        /// <summary>
        /// Ten, Jack, Queen, King, Ace, in same suit.
        /// </summary>
        Royal_Flush = 10,
    }
}
