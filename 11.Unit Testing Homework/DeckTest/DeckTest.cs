namespace DeckTest
{
    using System;
    using Santase.Logic.Cards;
    using NUnit.Framework;

    [TestFixture]
    public class DeckTest
    {
        [Test]
        public void TestingCreationOfDeck()
        {
            var deck = new Deck();
            var cardCount = 0;

            Assert.AreNotEqual(
                cardCount,
                deck.CardsLeft,
                string.Format("Expected {0} to not equal {1}",
                deck.CardsLeft,
                cardCount));
        }

        [Test]
        [TestCase(1)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(15)]
        public void TestingDeckGetNextCardShouldRemoveCard(int amountOfCardsToRemove)
        {
            var deck = new Deck();
            var cardCount = deck.CardsLeft;
            for (int i = 0; i < amountOfCardsToRemove; i++)
            {
                deck.GetNextCard();
            }

            cardCount -= amountOfCardsToRemove;
            Assert.AreEqual(
                cardCount,
                deck.CardsLeft,
                string.Format("Expected {0} to equal {1}",
                deck.CardsLeft,
                cardCount));
        }

        [Test]
        [ExpectedException(typeof(Santase.Logic.InternalGameException))]
        public void TestGetNextCardFromEmptyDeckThrowsException()
        {
            var deck = new Deck();
            int cardsCount = deck.CardsLeft;
            Card card = deck.GetNextCard();
            for (int i = 1; i <= cardsCount; i++)
            {
                card = deck.GetNextCard();
            }
        }
    }
}
