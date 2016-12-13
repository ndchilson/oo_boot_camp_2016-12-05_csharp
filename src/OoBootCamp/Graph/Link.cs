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

        internal Link(Node target)
        {
            _target = target;
        }

        internal double HopCount(Node destination, List<Node> visitedNodes)
        {
            return _target.HopCount(destination, visitedNodes);
        }
    }
}