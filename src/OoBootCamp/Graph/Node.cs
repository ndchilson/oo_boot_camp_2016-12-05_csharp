/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace OoBootCamp.Graph
{
    // Understands its neighbors
    public class Node
    {
        private List<Node> _neighbors = new List<Node>();
        private const int Unreachable = -1;

        public Node To(Node neighbor)
        {
            _neighbors.Add(neighbor);
            return neighbor;
        }

        public bool CanReach(Node destination)
        {
            return CanReach(destination, NoVisitedNodes());
        }

        private bool CanReach(Node destination, Collection<Node> visitedNodes)
        {
            if (this == destination) return true;
            if (visitedNodes.Contains(this)) return false;
            visitedNodes.Add(this);
            return _neighbors.Any(n => n.CanReach(destination, visitedNodes));
        }

        public int HopCount(Node destination)
        {
            var result = HopCount(destination, NoVisitedNodes());
            if (result == Unreachable) throw new InvalidOperationException("Unreachable destination");
            return result;
        }

        private int HopCount(Node destination, Collection<Node> visitedNodes)
        {
            if (this == destination) return 0;
            if (visitedNodes.Contains(this)) return Unreachable;
            visitedNodes.Add(this);
            return NeighborsHopCount(destination, visitedNodes);
        }

        private int NeighborsHopCount(Node destination, Collection<Node> visitedNodes)
        {
            foreach (var neighbor in this._neighbors)
            {
                var result = neighbor.HopCount(destination, visitedNodes);
                if (result != Unreachable) return result + 1;
            }
            return Unreachable;
        }

        private Collection<Node> NoVisitedNodes() => new Collection<Node>();
    }
}