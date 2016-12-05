/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Linq.Expressions;
using NUnit.Framework;

namespace OoBootCamp.Tests
{
    // Ensures Chance operates correctly
    [TestFixture]
    public class ChanceTest
    {

        [Test]
        public void Equality()
        {
            Assert.AreEqual(new Chance(0.25), new Chance(0.25));
            Assert.AreNotEqual(new Chance(0.25), new object());
            Assert.AreNotEqual(new Chance(0.25), null);
        }
         
        [Test]
        public void Hash()
        {
            Assert.AreEqual(new Chance(0.25).GetHashCode(), new Chance(0.25).GetHashCode());
        }

    }
}