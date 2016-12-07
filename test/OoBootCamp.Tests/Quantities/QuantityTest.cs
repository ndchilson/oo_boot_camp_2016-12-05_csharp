/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using NUnit.Framework;
using OoBootCamp.Quantities;
using static OoBootCamp.Quantities.Unit;

namespace OoBootCamp.Tests.Quantities
{
    // Ensures Quantity operates correctly
    [TestFixture]
    public class QuantityTest
    {
        [Test]
        public void EqualityOfSameUnit()
        {
            Assert.AreEqual(Tablespoon.s(2), Tablespoon.s(2));
            Assert.AreNotEqual(Tablespoon.s(2), Tablespoon.s(4));
            Assert.AreNotEqual(Tablespoon.s(2), new object());
            Assert.AreNotEqual(Tablespoon.s(2), null);
        }

        [Test]
        public void EqualityOfDifferentUnit()
        {
            Assert.AreNotEqual(Cup.s(4), Gallon.s(4));
            Assert.AreEqual(Teaspoon.s(3), Tablespoon.s(1));
            Assert.AreEqual(Ounce.s(16), Quart.s(0.5));
            Assert.AreEqual(Gallon.s(3), Teaspoon.s(2304));
        }

        [Test]
        public void Hash()
        {
            Assert.AreEqual(Tablespoon.s(2).GetHashCode(), Tablespoon.s(2).GetHashCode());
        }
    }
}