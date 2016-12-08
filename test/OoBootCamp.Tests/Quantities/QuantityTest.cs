/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Data;
using NUnit.Framework;
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
            Assert.AreEqual(Foot.s(4.5), Yard.s(1.5));
            Assert.AreEqual(Mile.s(2), Inch.es(126720));
            Assert.AreNotEqual(Inch.es(1), Teaspoon.s(1));
        }

        [Test]
        public void Hash()
        {
            Assert.AreEqual(Tablespoon.s(2).GetHashCode(), Tablespoon.s(2).GetHashCode());
            Assert.AreEqual(Ounce.s(16).GetHashCode(), Quart.s(0.5).GetHashCode());
        }

        [Test]
        public void Arithmetic()
        {
            Assert.AreEqual(-Ounce.s(4), -(Pint.s(0.25)));
            Assert.AreEqual(Cup.s(1), Ounce.s(4) + Pint.s(0.25));
            Assert.AreEqual(Pint.s(-0.25), Quart.s(0.25) - Ounce.s(12));
            Assert.AreEqual(-Foot.s(3), Inch.es(36) - Yard.s(2));
        }

        [Test]
        public void InvalidArithmetic()
        {
            Assert.That(delegate { return Foot.s(3) - Ounce.s(4); }, Throws.ArgumentException);
        }
    }
}