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
        private const double CertainFraction = 1.0;
        private const double Tolerance = 0.0000001;

        public Chance(double likelihoodAsFraction)
        {
            if (likelihoodAsFraction < 0.0 || likelihoodAsFraction > 1.0) throw new ArgumentException("Between 0.0 and 1.0");
            _fraction = likelihoodAsFraction;
        }

        public override bool Equals(object other)
        {
            return other is Chance && this.Equals((Chance)other);
        }

        private bool Equals(Chance other)
        {
            return Math.Abs(this._fraction - other._fraction) < Tolerance;
        }

        public override int GetHashCode()
        {
            return this._fraction.GetHashCode();
        }

        public static Chance operator !(Chance c)
        {
            return new Chance(CertainFraction - c._fraction);
        }

        public Chance Not()
        {
            return !this;
        }

        public static Chance operator &(Chance left, Chance right)
        {
            return new Chance(left._fraction * right._fraction);
        }

        public Chance And(Chance other)
        {
            return this & other;
        }

        // DeMorgan's Law: https://en.wikipedia.org/wiki/De_Morgan's_laws
        public static Chance operator |(Chance left, Chance right)
        {
            return !(!left & !right);
        }

        public Chance Or(Chance other)
        {
            return this | other;
        }
    }
}