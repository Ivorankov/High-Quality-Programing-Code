using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace TDD
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestingCardToStringShouldNotReturnNull()
        {
            var card = new Card(new CardFace(), new CardSuit());

            Assert.IsNotNull(card.ToString());
        }

        [TestMethod]
        public void TestingCardToStringShouldNotReturnEmptyString()
        {
            var card = new Card(new CardFace(), new CardSuit());
            var test = string.Empty;
            Assert.AreNotEqual(
                test,
                card.ToString(),
                string.Format("Expected {0} to not equal {1}",
                card.ToString(),
                test));
        }

        [TestMethod]
        public void TestingCardToStringShouldReturnCorrectString_SevenHearts()
        {

            var card = new Card(CardFace.Seven, CardSuit.Hearts);
            var test = "7" + " " + "♥";

            Assert.AreEqual(
                test,
                card.ToString(),
                string.Format("The value {0} does not equal the expected {1}",
                card.ToString(),
                test));
        }

        [TestMethod]
        public void TestingCardToStringShouldReturnCorrectString_TenClubs()
        {

            var card = new Card(CardFace.Ten, CardSuit.Clubs);
            var test = "10" + " " + "♣";

            Assert.AreEqual(
                test,
                card.ToString(),
                string.Format("The value {0} does not equal the expected {1}",
                card.ToString(),
                test));
        }

        [TestMethod]
        public void TestingCardToStringShouldReturnCorrectString_AceSpades()
        {

            var card = new Card(CardFace.Ace, CardSuit.Spades);
            var test = "A" + " " + "♠";

            Assert.AreEqual(
                test,
                card.ToString(),
                string.Format("The value {0} does not equal the expected {1}",
                card.ToString(),
                test));
        }

        [TestMethod]
        public void TestingCardToStringShouldReturnCorrectString_JackDiamond()
        {

            var card = new Card(CardFace.Jack, CardSuit.Diamonds);
            var test = "J" + " " + "♦";

            Assert.AreEqual(
                test,
                card.ToString(),
                string.Format("The value {0} does not equal the expected {1}",
                card.ToString(),
                test));
        }

    }
}
