/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;

namespace OoBootCamp.Graph
{
    // Understands a specific way from one Node to another Node
    public class Path : IComparable<Path>
    {
        private readonly List<Link> _links = new List<Link>();

        internal Path PrePend(Link link)
        {
            _links.Insert(0, link);
            return this;
        }

        public int HopCount()
        {
            return _links.Count;
        }

        public double Cost()
        {
            return Link.TotalCost(_links);
        }

        public int CompareTo(Path other)
        {
            return this.Cost().CompareTo(other.Cost());
        }
    }
}