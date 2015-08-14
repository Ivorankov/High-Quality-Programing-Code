using System;
using System.Collections;
using System.Collections.Generic;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            var str = string.Empty;

            foreach (var card in Cards)
            {
                str += card.ToString();
                str += " ";
            }

            return str;
        }
    }
}
