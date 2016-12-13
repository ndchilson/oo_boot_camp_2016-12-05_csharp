/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace OoBootCamp.Graph
{
    // Understands its neighbors
    public class Node
    {
        private readonly List<Link> _links = new List<Link>();
        private const double Unreachable = Double.PositiveInfinity;

        public Node To(Node neighbor)
        {
            this._links.Add(new Link(neighbor));
            return neighbor;
        }

        public bool CanReach(Node destination)
        {
            return HopCount(destination, NoVisitedNodes()) != Unreachable;
        }

        public int HopCount(Node destination)
        {
            var result = HopCount(destination, NoVisitedNodes());
            if (result == Unreachable) throw new InvalidOperationException("Unreachable destination");
            return (int)result;
        }

        internal double HopCount(Node destination, List<Node> visitedNodes)
        {
            if (this == destination) return 0;
            if (visitedNodes.Contains(this)) return Unreachable;
            if (this._links.Count == 0) return Unreachable;
            return _links
                       .ConvertAll(link => link.HopCount(destination, CopyWithThis(visitedNodes)))
                       .Min();
        }

        private List<Node> CopyWithThis(List<Node> originals)
        {
            return new List<Node>(originals) { this };
        }

        private List<Node> NoVisitedNodes() => new List<Node>();
    }
}