/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using static OoBootCamp.Graph.Link;

namespace OoBootCamp.Graph
{
    // Understands its neighbors
    public class Node
    {
        private readonly List<Link> _links = new List<Link>();
        private const double Unreachable = Double.PositiveInfinity;

        public Node To(Node neighbor, double cost)
        {
            this._links.Add(new Link(neighbor, cost));
            return neighbor;
        }

        public bool CanReach(Node destination)
        {
            return Cost(destination, NoVisitedNodes(), LeastCost) != Unreachable;
        }

        public int HopCount(Node destination)
        {
            return (int)SafeCost(destination, FewestHops);
        }

        public double Cost(Node destination)
            {
            return SafeCost(destination, LeastCost);
        }

        private double SafeCost(Node destination, CostStrategy strategy)
        {
            var result = Cost(destination, NoVisitedNodes(), strategy);
            if (result == Unreachable) throw new InvalidOperationException("Unreachable destination");
            return result;
        }

        internal double Cost(Node destination, List<Node> visitedNodes, CostStrategy strategy)
        {
            if (this == destination) return 0;
            if (visitedNodes.Contains(this)) return Unreachable;
            if (this._links.Count == 0) return Unreachable;
            return _links
                       .ConvertAll(link => link.Cost(destination, CopyWithThis(visitedNodes), strategy))
                       .Min();
        }

        public Path Path(Node destination)
        {
            var result = Path(destination, NoVisitedNodes());
            if (result is NoPath) throw new InvalidOperationException("Unreachable destination");
            return result;
        }

        internal Path Path(Node destination, List<Node> visitedNodes)
        {
            if (this == destination) return new ActualPath();
            if (visitedNodes.Contains(this)) return new NoPath();
            var paths = _links.ConvertAll(link => link.Path(destination, CopyWithThis(visitedNodes)));
            return (paths.Count == 0) ? new NoPath() : paths.Min();
        }

        private List<Node> CopyWithThis(List<Node> originals) => new List<Node>(originals) { this };

        private List<Node> NoVisitedNodes() => new List<Node>();
    }
}