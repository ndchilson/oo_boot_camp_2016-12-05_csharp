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
    }
}