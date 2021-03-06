﻿using System;
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
            Card notAFaceCard = new Card(10, Suit.Spades);
            Card faceCard2 = new Card(11, Suit.Spades);
            Card faceCard3 = new Card(13, Suit.Spades);

            Assert.IsFalse(notAFaceCard.IsFaceCard);
            Assert.IsTrue(faceCard2.IsFaceCard);
            Assert.IsTrue(faceCard3.IsFaceCard);
        }

        [Test]
        [ExpectedException]
        public void Constructor_InvalidValue_ExceptionThrown()
        {
            Card outOfBoundsCard = new Card(14, Suit.Spades);
        }
    }
}
