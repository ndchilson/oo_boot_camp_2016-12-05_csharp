/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Collections.Generic;
using System.Linq;

namespace OoBootCamp.Graph
{
    // Understands a connection to a specific Node
    public class Link
    {
        internal delegate double CostStrategy(double cost);
        internal static CostStrategy LeastCost = cost => cost;
        internal static CostStrategy FewestHops = cost => 1;

        private readonly Node _target;
        private readonly double _cost;

        internal Link(Node target, double cost)
        {
            _target = target;
            _cost = cost;
        }

        internal double Cost(Node destination, List<Node> visitedNodes, CostStrategy strategy)
        {
            return _target.Cost(destination, visitedNodes, strategy) + strategy(_cost);
        }

        internal Path Path(Node destination, List<Node> visitedNodes)
        {
            return this._target.Path(destination, visitedNodes)?.Prepend(this);
        }

        public static double TotalCost(List<Link> links)
        {
            if (!links.Any()) return 0.0;
            return links.ConvertAll(link => link._cost).Sum();
        }
    }
}