using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace E1evens.Tests
{
    [TestFixture]
    public class CardListTest
    {
        [Test]
        public void Shuffle_52UniqueCards()
        {
            CardList deck = CardList.CreateStandardDeck();

            deck.Shuffle();

            for (int value = 1; value < 14; value++)
            {
                Assert.IsTrue(deck.Contains(new Card(value, Suit.Clubs)));
                Assert.IsTrue(deck.Contains(new Card(value, Suit.Diamonds)));
                Assert.IsTrue(deck.Contains(new Card(value, Suit.Hearts)));
                Assert.IsTrue(deck.Contains(new Card(value, Suit.Spades)));
            }

            Assert.AreEqual(52, deck.Count);
        }
    }
}
