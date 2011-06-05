using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace E1evens.Tests
{
    [TestFixture]
    public class CardTest
    {
        [Test]
        public void IsFaceCard()
        {
            Card notAFaceCard = new Card(Suit.Spades, 10);
            Card faceCard2 = new Card(Suit.Spades, 11);
            Card faceCard3 = new Card(Suit.Spades, 13);

            Assert.IsFalse(notAFaceCard.IsFaceCard);
            Assert.IsTrue(faceCard2.IsFaceCard);
            Assert.IsTrue(faceCard3.IsFaceCard);
        }

        [Test]
        [ExpectedException]
        public void Constructor_InvalidValue_ExceptionThrown()
        {
            Card outOfBoundsCard = new Card(Suit.Spades, 14);
        }
    }
}
