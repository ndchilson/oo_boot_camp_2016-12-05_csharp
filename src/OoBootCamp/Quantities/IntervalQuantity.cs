/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
using System;

namespace OoBootCamp.Quantities
{
    // Understands a specific measurement
    public class IntervalQuantity
    {
        private readonly double _amount;
        private readonly Unit _unit;

        private const double Tolerance = 0.000001;

        protected internal IntervalQuantity(double amount, Unit unit)
        {
            _amount = amount;
            _unit = unit;
        }

        public override bool Equals(object other)
        {
            if (!(other is IntervalQuantity)) return false;
            return this.Equals(other as IntervalQuantity);
        }

        private bool Equals(IntervalQuantity other)
        {
            if (!this._unit.IsCompatible(other._unit)) return false;
            return Math.Abs(this._amount - ConvertedAmount(other)) < Tolerance;
        }

        public override int GetHashCode()
        {
            return _unit.Hash(_amount);
        }

        private double ConvertedAmount(IntervalQuantity other)
        {
            return this._unit.ConvertedAmount(other._amount, other._unit);
        }
    }
}