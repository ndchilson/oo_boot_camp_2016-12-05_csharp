﻿/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using NUnit.Framework;
using OoBootCamp.Graph;

namespace OoBootCamp.Tests.Graph
{
    // Ensures that operations on graphs are correct
    [TestFixture]
    public class GraphTest
    {
        private static readonly Node A = new Node();
        private static readonly Node B = new Node();
        private static readonly Node C = new Node();
        private static readonly Node D = new Node();
        private static readonly Node E = new Node();
        private static readonly Node F = new Node();
        private static readonly Node G = new Node();
                                                     
        static GraphTest()
        {
            B.To(A, 7);
            B.To(C, 5).To(D, 2).To(E, 3).To(B, 4).To(F, 6);
            C.To(D, 1);
            C.To(E, 8);
        }

        [Test]
        public void CanReach()
        {
            Assert.IsTrue(A.CanReach(A));
            Assert.IsTrue(B.CanReach(A));
            Assert.IsFalse(A.CanReach(B));
            Assert.IsTrue(B.CanReach(F));
            Assert.IsTrue(C.CanReach(F));
            Assert.IsFalse(G.CanReach(B));
            Assert.IsFalse(B.CanReach(G));
        }

        [Test]
        public void HopCount()
        {
            Assert.AreEqual(0, A.HopCount(A));
            Assert.AreEqual(1, B.HopCount(A));
            Assert.AreEqual(1, B.HopCount(F));
            Assert.AreEqual(3, C.HopCount(F));
            Assert.Throws<InvalidOperationException>(delegate { A.HopCount(B); });
            Assert.Throws<InvalidOperationException>(delegate { G.HopCount(B); });
            Assert.Throws<InvalidOperationException>(delegate { B.HopCount(G); });
        }

        [Test]
        public void Cost()
        {
            Assert.AreEqual(0, A.Cost(A));
            Assert.AreEqual(7, B.Cost(A));
            Assert.AreEqual(6, B.Cost(F));
            Assert.AreEqual(14, C.Cost(F));
            Assert.Throws<InvalidOperationException>(delegate { A.Cost(B); });
            Assert.Throws<InvalidOperationException>(delegate { G.Cost(B); });
            Assert.Throws<InvalidOperationException>(delegate { B.Cost(G); });
        }

        [Test]
        public void Path()
        {
            AssertPath(A, A, 0, 0);
            AssertPath(B, A, 1, 7);
            AssertPath(B, F, 1, 6);
            AssertPath(C, F, 4, 14);
            Assert.Throws<InvalidOperationException>(delegate { A.Path(B); });
            Assert.Throws<InvalidOperationException>(delegate { G.Path(B); });
            Assert.Throws<InvalidOperationException>(delegate { B.Path(G); });
        }

        private void AssertPath(Node start, Node destination, int expectedHopCount, double expectedCost)
        {
            var path = start.Path(destination);
            Assert.AreEqual(expectedHopCount, path.HopCount());
            Assert.AreEqual(expectedCost, path.Cost());
        }
    }
}