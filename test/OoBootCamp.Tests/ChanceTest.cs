/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
 
using NUnit.Framework;

namespace OoBootCamp.Tests
{
    // Ensures Chance operates correctly
    [TestFixture]
    public class ChanceTest
    {
        private static readonly Chance Impossible = new Chance(0.0);
        private static readonly Chance Unlikely = new Chance(0.25);
        private static readonly Chance EquallyLikely = new Chance(0.5);
        private static readonly Chance Likely = new Chance(0.75);
        private static readonly Chance Certain = new Chance(1.0);

        [Test]
        public void Equality()
        {
            Assert.AreEqual(new Chance(0.25), Unlikely);
            Assert.AreNotEqual(Unlikely, new object());
            Assert.AreNotEqual(Unlikely, null);
        }
         
        [Test]
        public void Hash()
        {
            Assert.AreEqual(new Chance(0.25).GetHashCode(), Unlikely.GetHashCode());
        }

        [Test]
        public void Validation()
        {
            Assert.That(() => new Chance(-0.1), Throws.ArgumentException);
            Assert.That(() => new Chance(1.1), Throws.ArgumentException);
        }

        [Test]
        public void Not()
        {
            Assert.AreEqual(Unlikely, Likely.Not());
            Assert.AreEqual(Likely, Likely.Not().Not());
            Assert.AreEqual(Impossible, Certain.Not());
        }

        [Test]
        public void And()
        {
            Assert.AreEqual(Unlikely, EquallyLikely.And(EquallyLikely));
            Assert.AreEqual(new Chance(0.1875), Unlikely.And(Likely));
            Assert.AreEqual(Likely.And(Unlikely), Unlikely.And(Likely));
            Assert.AreEqual(Likely, Certain.And(Likely));
            Assert.AreEqual(Impossible, Likely.And(Impossible));
        }

        [Test]
        public void Or()
        {
            Assert.AreEqual(Likely, EquallyLikely.Or(EquallyLikely));
            Assert.AreEqual(new Chance(0.8125), Unlikely.Or(Likely));
            Assert.AreEqual(Likely.Or(Unlikely), Unlikely.Or(Likely));
            Assert.AreEqual(Certain, Certain.Or(Likely));
            Assert.AreEqual(Likely, Likely.Or(Impossible));
        }
    }
}