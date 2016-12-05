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
        public void Not()
        {
            Assert.AreEqual(Unlikely, Likely.Not());
            Assert.AreEqual(Likely, Likely.Not().Not());
            Assert.AreEqual(Impossible, Certain.Not());
        }
    }
}