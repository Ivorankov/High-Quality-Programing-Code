using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace TDD
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void TestingHandToStringMethodShouldNotReturnNull()
        {
            IList<ICard> list = new List<ICard>();
            for (int i = 0; i < 10; i += 1)
            {
                list.Add(new Card(new CardFace(), new CardSuit()));
            }
            var hand = new Hand(list);

            Assert.IsNotNull(hand.ToString());
        }

        [TestMethod]
        public void TestingHandToStringMethodShouldNotReturnEmptyString()
        {
            IList<ICard> list = new List<ICard>();
            for (int i = 0; i < 10; i += 1)
            {
                list.Add(new Card(new CardFace(), new CardSuit()));
            }
            var hand = new Hand(list);
            string test = string.Empty;
            Assert.AreNotEqual(
                    test,
                    hand.ToString(),
                    string.Format("Expected {0} to not equal {1}",
                    hand.ToString(),
                    test));
        }

        [TestMethod]
        public void TestingHandToStringMethodShouldReturnCorrectString()
        {
            IList<ICard> list = new List<ICard>();
            string testResult = string.Empty;
            for (int i = 0; i < 10; i += 1)
            {
                list.Add(new Card(CardFace.Six, CardSuit.Diamonds));
            }

            foreach (var card in list)
            {
                testResult += card.ToString();
                testResult += " ";
            }

            var hand = new Hand(list);

            Assert.AreEqual(
                testResult,
                hand.ToString(),
                string.Format("The value {0} does not equal the expected {1}",
                hand.ToString(),
                testResult));
        }
    }
}
