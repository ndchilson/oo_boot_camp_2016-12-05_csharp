/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
using System;

namespace OoBootCamp.Quantities
{
    // Understands a specific measurement
    public class RatioQuantity
    {
        private readonly double _amount;
        private readonly Unit _unit;

        private const double Tolerance = 0.000001;

        protected internal RatioQuantity(double amount, Unit unit)
        {
            _amount = amount;
            _unit = unit;
        }

        public override bool Equals(object other)
        {
            if (!(other is RatioQuantity)) return false;
            return this.Equals(other as RatioQuantity);
        }

        private bool Equals(RatioQuantity other)
        {
            if (!this._unit.IsCompatible(other._unit)) return false;
            return Math.Abs(this._amount - ConvertedAmount(other)) < Tolerance;
        }

        public override int GetHashCode()
        {
            return _unit.Hash(_amount);
        }

        private double ConvertedAmount(RatioQuantity other)
        {
            return this._unit.ConvertedAmount(other._amount, other._unit);
        }

        public static RatioQuantity operator -(RatioQuantity q)
        {
            return new RatioQuantity(-q._amount, q._unit);
        }

        public static RatioQuantity operator +(RatioQuantity left, RatioQuantity right)
        {
            return new RatioQuantity(left._amount + left.ConvertedAmount(right), left._unit);
        }

        public static RatioQuantity operator -(RatioQuantity left, RatioQuantity right)
        {
            return left + -right;
        }
    }
}