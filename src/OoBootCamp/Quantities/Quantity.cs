/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
using System;
using System.Runtime.CompilerServices;

namespace OoBootCamp.Quantities
{
    // Understands a specific measurement
    public class Quantity
    {
        private readonly double _amount;
        private readonly Unit _unit;

        private const double Tolerance = 0.000001;

        protected internal Quantity(double amount, Unit unit)
        {
            _amount = amount;
            _unit = unit;
        }

        public override bool Equals(object other)
        {
            if (!(other is Quantity)) return false;
            return this.Equals(other as Quantity);
        }

        private bool Equals(Quantity other)
        {
            if (!this._unit.IsCompatible(other._unit)) return false;
            return Math.Abs(this._amount - ConvertedAmount(other)) < Tolerance;
        }

        public override int GetHashCode()
        {
            return _unit.Hash(_amount);
        }

        private double ConvertedAmount(Quantity other)
        {
            return this._unit.ConvertedAmount(other._amount, other._unit);
        }

        public static Quantity operator -(Quantity q)
        {
            return new Quantity(-q._amount, q._unit);
        }

        public static Quantity operator +(Quantity left, Quantity right)
        {
            return new Quantity(left._amount + left.ConvertedAmount(right), left._unit);
        }

        public static Quantity operator -(Quantity left, Quantity right)
        {
            return left + -right;
        }
    }
}