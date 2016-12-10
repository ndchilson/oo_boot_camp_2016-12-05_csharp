/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using NUnit.Framework;

namespace OoBootCamp.Tests
{
    // Ensures Rectangle operates correctly
    [TestFixture]
    public class RectangleTest
    {
        [Test]
        public void Area()
        {
            Assert.AreEqual(24, new Rectangle(4, 6).Area());
            Assert.AreEqual(25, Rectangle.Square(5).Area());
        }

        [Test]
        public void Perimeter()
        {
            Assert.AreEqual(20, new Rectangle(4, 6).Perimeter());
            Assert.AreEqual(20, Rectangle.Square(5).Perimeter());
        }

        [Test]
        public void InvalidRectangles()
        {
            Assert.That(delegate { return new Rectangle(0, 1); }, Throws.ArgumentException);
            Assert.That(delegate { return new Rectangle(1, 0); }, Throws.ArgumentException);
        }
    }
}
