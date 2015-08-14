using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Poker;

namespace TDD
{
    [TestClass]
    public class PokerHandsCheckerTest
    {
        [TestMethod]
        public void TestingPokerHandCheckerIsValidHandShouldPass()
        {
            IList<ICard> list = new List<ICard>();
            list.Add(new Card(CardFace.Nine, CardSuit.Spades));
            list.Add(new Card(CardFace.Two, CardSuit.Spades));
            list.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            list.Add(new Card(CardFace.Ace, CardSuit.Spades));
            list.Add(new Card(CardFace.Jack, CardSuit.Clubs));

            var hand = new Hand(list);

            var test = new PokerHandsChecker();

            Assert.IsTrue(test.IsValidHand(hand));     
        }

        [TestMethod]
        public void TestingPokerHandCheckerIsValidHandShouldFail()
        {
            IList<ICard> list = new List<ICard>();
            list.Add(new Card(CardFace.Nine, CardSuit.Spades));
            list.Add(new Card(CardFace.Two, CardSuit.Spades));
            list.Add(new Card(CardFace.Ten, CardSuit.Hearts));
            list.Add(new Card(CardFace.Two, CardSuit.Spades));
            list.Add(new Card(CardFace.Jack, CardSuit.Clubs));

            var hand = new Hand(list);

            var test = new PokerHandsChecker();

            Assert.IsFalse(test.IsValidHand(hand));
        }

        [TestMethod]
        public void TestingPokerHandCheckerIsFlushShouldPass()
        {
            IList<ICard> list = new List<ICard>();
            list.Add(new Card(CardFace.Nine, CardSuit.Spades));
            list.Add(new Card(CardFace.Two, CardSuit.Spades));
            list.Add(new Card(CardFace.Ten, CardSuit.Spades));
            list.Add(new Card(CardFace.Two, CardSuit.Spades));
            list.Add(new Card(CardFace.Jack, CardSuit.Spades));

            var hand = new Hand(list);

            var test = new PokerHandsChecker();

            Assert.IsTrue(test.IsFlush(hand));
        }

        [TestMethod]
        public void TestingPokerHandCheckerIsFlushShouldFail()
        {
            IList<ICard> list = new List<ICard>();
            list.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            list.Add(new Card(CardFace.Two, CardSuit.Spades));
            list.Add(new Card(CardFace.Ten, CardSuit.Spades));
            list.Add(new Card(CardFace.Two, CardSuit.Spades));
            list.Add(new Card(CardFace.Jack, CardSuit.Spades));

            var hand = new Hand(list);

            var test = new PokerHandsChecker();

            Assert.IsFalse(test.IsFlush(hand));
        }

        [TestMethod]
        public void TestingPokerHandCheckerIsFourOFAKindShouldPass()
        {
            IList<ICard> list = new List<ICard>();
            list.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            list.Add(new Card(CardFace.Ace, CardSuit.Spades));
            list.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            list.Add(new Card(CardFace.Ace, CardSuit.Spades));
            list.Add(new Card(CardFace.Ace, CardSuit.Hearts));

            var hand = new Hand(list);

            var test = new PokerHandsChecker();

            Assert.IsTrue(test.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void TestingPokerHandCheckerIsFourOFAKindShouldFail()
        {
            IList<ICard> list = new List<ICard>();
            list.Add(new Card(CardFace.Nine, CardSuit.Clubs));
            list.Add(new Card(CardFace.Two, CardSuit.Spades));
            list.Add(new Card(CardFace.Ten, CardSuit.Spades));
            list.Add(new Card(CardFace.Two, CardSuit.Spades));
            list.Add(new Card(CardFace.Two, CardSuit.Spades));

            var hand = new Hand(list);

            var test = new PokerHandsChecker();

            Assert.IsFalse(test.IsFourOfAKind(hand));
        }
    }
}
