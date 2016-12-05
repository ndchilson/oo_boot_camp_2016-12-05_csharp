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

        public Chance(double likelihoodAsFraction)
        {
            if (likelihoodAsFraction < 0.0 || likelihoodAsFraction > 1.0) throw new ArgumentException("Between 0.0 and 1.0");
            _fraction = likelihoodAsFraction;
        }

        public override bool Equals(object other)
        {
            if (!(other is Chance)) return false;
            return this.Equals(other as Chance);
        }

        private bool Equals(Chance other) => this._fraction == other._fraction;

        public override int GetHashCode() => _fraction.GetHashCode();

        public static Chance operator !(Chance c)
        {
            return new Chance(CertainFraction - c._fraction);
        }

        public Chance Not() => !this;

        public static Chance operator &(Chance left, Chance right)
        {
            return new Chance(left._fraction * right._fraction);
        }

        public Chance And(Chance other) => this & other;

        // DeMorgan's Law: https://en.wikipedia.org/wiki/De_Morgan's_laws
        public static Chance operator |(Chance left, Chance right)
        {
            return left.Not().And(right.Not()).Not();
        }

        public Chance Or(Chance other) => this | other;
    }
}