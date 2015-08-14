using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            var str = string.Empty;
            str += SetCardFace((int)this.Face);
            str += " ";
            str += SetCardSuit((int)this.Suit);

            return str;
        }

        private string SetCardFace(int cardNumber)
        {
            switch (cardNumber)
            {
                case 2: return "2";
                case 3: return "3";
                case 4: return "4";
                case 5: return "5";
                case 6: return "6";
                case 7: return "7";
                case 8: return "8";
                case 9: return "9";
                case 10: return "10";
                case 11: return "J";
                case 12: return "Q";
                case 13: return "K";
                case 14: return "A";
                default: return "Invalid card face number";
            }
        }

        private string SetCardSuit(int cardSuitNumber)
        {
            switch (cardSuitNumber)
            {
                case 1: return "♣";
                case 2: return "♦";
                case 3: return "♥";
                case 4: return "♠";
                default: return "Invalid card suit number";
            }
        }
    }
}
