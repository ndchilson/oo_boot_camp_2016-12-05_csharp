/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
using System;

namespace OoBootCamp.Quantities
{
    // Understands a specific measurement of an Interval metric
    public class IntervalQuantity
    {
        protected internal readonly double Amount;
        protected internal readonly Unit Unit;

        private const double Tolerance = 0.000001;

        protected internal IntervalQuantity(double amount, Unit unit)
        {
            Amount = amount;
            Unit = unit;
        }

        public override bool Equals(object other)
        {
            if (!(other is IntervalQuantity)) return false;
            return this.Equals(other as IntervalQuantity);
        }

        private bool Equals(IntervalQuantity other)
        {
            if (!this.Unit.IsCompatible(other.Unit)) return false;
            return Math.Abs(this.Amount - ConvertedAmount(other)) < Tolerance;
        }

        public override int GetHashCode()
        {
            return Unit.Hash(this.Amount);
        }

        protected internal double ConvertedAmount(IntervalQuantity other)
        {
            return this.Unit.ConvertedAmount(other.Amount, other.Unit);
        }
    }
}