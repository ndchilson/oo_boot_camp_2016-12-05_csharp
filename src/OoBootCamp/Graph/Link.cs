/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Collections.Generic;

namespace OoBootCamp.Graph
{
    // Understands a connection to a specific Node
    class Link
    {
        private readonly Node _target;
        private readonly double _cost;

        internal Link(Node target, double cost)
        {
            _target = target;
            _cost = cost;
        }

        internal double HopCount(Node destination, List<Node> visitedNodes)
        {
            return _target.HopCount(destination, visitedNodes) + 1;
        }

        internal double Cost(Node destination, List<Node> visitedNodes)
        {
            return _target.Cost(destination, visitedNodes) + _cost;
        }
    }
}