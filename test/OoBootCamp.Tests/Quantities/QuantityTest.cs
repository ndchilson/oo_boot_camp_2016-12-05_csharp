/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using NUnit.Framework;
using OoBootCamp.Quantities;
using static OoBootCamp.Quantities.Quantity;

namespace OoBootCamp.Tests.Quantities
{
    // Ensures Quantity operates correctly
    [TestFixture]
    public class QuantityTest
    {
        [Test]
        public void EqualityOfSameUnit()
        {
            Assert.AreEqual(new Quantity(2, Tablespoon), new Quantity(2, Tablespoon));
            Assert.AreNotEqual(new Quantity(2, Tablespoon), new Quantity(4, Tablespoon));
            Assert.AreNotEqual(new Quantity(2, Tablespoon), new object());
            Assert.AreNotEqual(new Quantity(2, Tablespoon), null);
        }

        [Test]
        public void EqualityOfDifferentUnit()
        {
            Assert.AreNotEqual(new Quantity(4, Cup), new Quantity(4, Gallon));
        }

        [Test]
        public void Hash()
        {
            Assert.AreEqual(new Quantity(2, Tablespoon).GetHashCode(), new Quantity(2, Tablespoon).GetHashCode());
        }
    }
}