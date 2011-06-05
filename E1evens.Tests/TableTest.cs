using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace E1evens.Tests
{
    [TestFixture]
    public class TableTest
    {
        [Test]
        public void IsStuck_PlaceOnePossible_ReturnsFalse()
        {

        }

        [Test]
        public void IsStuck_PlaceTwoPossible_ReturnsFalse()
        {
            Table table = new Table();

            // need a table with all cards down and an 11 pair

            Assert.IsFalse(table.IsStuck);


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
