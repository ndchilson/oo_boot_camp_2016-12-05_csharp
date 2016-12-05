/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
using System;

namespace OoBootCamp
{
    // Understands the likelihood of something occuring
    public class Chance
    {
        private readonly double _fraction;
        private static readonly double CertainFraction = 1.0;

        public Chance(double likelihoodAsFraction)
        {
            _fraction = likelihoodAsFraction;
        }

        public override bool Equals(object other)
        {
            if (!(other is Chance)) return false;
            return this.Equals(other as Chance);
        }

        private bool Equals(Chance other)
        {
            return this._fraction == other._fraction;
        }

        public override int GetHashCode()
        {
            return _fraction.GetHashCode();
        }

        public Chance Not()
        {
            return new Chance(CertainFraction - _fraction);
        }

        public Chance And(Chance other)
        {
            return new Chance(this._fraction * other._fraction);
        }

        // DeMorgan's Law: https://en.wikipedia.org/wiki/De_Morgan's_laws
        public Chance Or(Chance other)
        {
            return this.Not().And(other.Not()).Not();
        }
    }
}