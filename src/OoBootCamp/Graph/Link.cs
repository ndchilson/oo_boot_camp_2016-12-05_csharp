﻿/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Collections.Generic;

namespace OoBootCamp.Graph
{
    // Understands a connection to a specific Node
    class Link
    {
        internal delegate double CostStrategy(double cost);
        internal static CostStrategy LeastCost = (double cost) => cost;
        internal static CostStrategy FewestHops = (double cost) => 1;

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
    }
}