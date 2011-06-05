using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace E1evens.Tests
{
    [TestFixture]
    public class DeckTest
    {
        [Test]
        public void Shuffle_52UniqueCards()
        {
            Deck deck = new Deck();
            deck.Shuffle();

            for (int value = 1; value < 14; value++)
            {
                Assert.IsTrue(deck.Cards.Contains(new Card(Suit.Clubs, value)));
                Assert.IsTrue(deck.Cards.Contains(new Card(Suit.Diamonds, value)));
                Assert.IsTrue(deck.Cards.Contains(new Card(Suit.Hearts, value)));
                Assert.IsTrue(deck.Cards.Contains(new Card(Suit.Spades, value)));
            }

            Assert.AreEqual(52, deck.Cards.Count);
        }
    }
}
