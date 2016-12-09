/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
 
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
            Assert.AreEqual(Tablespoon.S(2), Tablespoon.S(2));
            Assert.AreNotEqual(Tablespoon.S(2), Tablespoon.S(4));
            Assert.AreNotEqual(Tablespoon.S(2), new object());
            Assert.AreNotEqual(Tablespoon.S(2), null);
        }

        [Test]
        public void EqualityOfDifferentUnit()
        {
            Assert.AreNotEqual(Cup.S(4), Gallon.S(4));
            Assert.AreEqual(Teaspoon.S(3), Tablespoon.S(1));
            Assert.AreEqual(Ounce.S(16), Quart.S(0.5));
            Assert.AreEqual(Gallon.S(3), Teaspoon.S(2304));
            Assert.AreEqual(Foot.S(4.5), Yard.S(1.5));
            Assert.AreEqual(Mile.S(2), Inch.Es(126720));
            Assert.AreNotEqual(Inch.Es(1), Teaspoon.S(1));
            Assert.AreNotEqual(Inch.Es(1), Celsius.S(1));
        }

        [Test]
        public void Temperature()
        {
            Assert.AreEqual(Celsius.S(100), Fahrenheit.S(212));
            Assert.AreEqual(Fahrenheit.S(212), Celsius.S(100));
            Assert.AreEqual(Celsius.S(10), Fahrenheit.S(50));
            Assert.AreEqual(Fahrenheit.S(50), Celsius.S(10));
            Assert.AreEqual(Celsius.S(0), Fahrenheit.S(32));
            Assert.AreEqual(Fahrenheit.S(32), Celsius.S(0));
            Assert.AreEqual(Celsius.S(-40), Fahrenheit.S(-40));
            Assert.AreEqual(Fahrenheit.S(-40), Celsius.S(-40));
        }

        [Test]
        public void Hash()
        {
            Assert.AreEqual(Tablespoon.S(2).GetHashCode(), Tablespoon.S(2).GetHashCode());
            Assert.AreEqual(Ounce.S(16).GetHashCode(), Quart.S(0.5).GetHashCode());
        }

        [Test]
        public void Arithmetic()
        {
            Assert.AreEqual(-Ounce.S(4), -(Pint.S(0.25)));
            Assert.AreEqual(Cup.S(1), Ounce.S(4) + Pint.S(0.25));
            Assert.AreEqual(Pint.S(-0.25), Quart.S(0.25) - Ounce.S(12));
            Assert.AreEqual(-Foot.S(3), Inch.Es(36) - Yard.S(2));
        }

        [Test]
        public void InvalidArithmetic()
        {
            Assert.That(delegate { return Foot.S(3) - Ounce.S(4); }, Throws.ArgumentException);
            // The following should not compile:
            //var total = Celsius.S(10) + Fahrenheit.S(50);
            //var total = Inch.Es(10) + Fahrenheit.S(50);
        }
    }
}