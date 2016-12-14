/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;

namespace OoBootCamp.Graph
{
    public interface Path : IComparable<Path>
    {
        Path Prepend(Link link);
        int HopCount();
        double Cost();
    }

    class NoPath : Path
    {
        public int CompareTo(Path other)
        {
            return 1;
        }

        public Path Prepend(Link ignore)
        {
            return this;
        }

        public int HopCount()
        {
            return int.MaxValue;
        }

        public double Cost()
        {
            return double.PositiveInfinity;
        }
    }

    // Understands a specific way from one Node to another Node
    class ActualPath : Path
    {
        private readonly List<Link> _links = new List<Link>();

        internal ActualPath() { }

        public Path Prepend(Link link)
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