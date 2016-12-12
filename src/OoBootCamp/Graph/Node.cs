/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OoBootCamp.Graph
{
    // Understands its neighbors
    public class Node
    {
        private List<Node> _neighbors = new List<Node>();

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
            return _neighbors.Exists(n => n.CanReach(destination, visitedNodes));
        }

        private Collection<Node> NoVisitedNodes() => new Collection<Node>();
    }
}