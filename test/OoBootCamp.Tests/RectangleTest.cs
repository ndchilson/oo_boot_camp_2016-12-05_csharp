/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
