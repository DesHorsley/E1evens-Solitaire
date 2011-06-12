using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace E1evens.Tests
{
    [TestFixture]
    public class SeatTest
    {
        [Test]
        public void IsStuck_PlaceOnePossible_ReturnsFalse()
        {
            Seat seat = new Seat();

            seat.Positions[0].Add(new Card(1, Suit.Diamonds));

            Assert.IsFalse(seat.IsStuck);
        }

        [Test]
        public void IsStuck_PlaceTwoPossible_ReturnsFalse()
        {
            Seat seat = new Seat();

            seat.Positions[0].Add(new Card(1, Suit.Diamonds));
            seat.Positions[1].Add(new Card(2, Suit.Clubs));
            seat.Positions[2].Add(new Card(3, Suit.Hearts));
            seat.Positions[3].Add(new Card(4, Suit.Spades));
            seat.Positions[4].Add(new Card(5, Suit.Clubs));
            seat.Positions[5].Add(new Card(5, Suit.Diamonds));
            seat.Positions[6].Add(new Card(4, Suit.Diamonds));
            seat.Positions[7].Add(new Card(3, Suit.Spades));
            seat.Positions[8].Add(new Card(6, Suit.Diamonds));
            Assert.IsFalse(seat.IsStuck);

        }

        [Test]
        public void IsStuck_PlaceThreePossible_ReturnsFalse()
        {

        }

        [Test]
        public void IsStuck_NoMovesPossible_ReturnsTrue()
        {

        }


    }
}
