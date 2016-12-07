/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
using System;

namespace OoBootCamp.Quantities
{
    public class Quantity
    {
        public static readonly object Teaspoon = new object();
        public static readonly object Tablespoon = new object();
        public static readonly object Ounce = new object();
        public static readonly object Cup = new object();
        public static readonly object Pint = new object();
        public static readonly object Quart = new object();
        public static readonly object Gallon = new object();

        private readonly double _amount;
        private readonly object _unit;

        private const double Tolerance = 0.000001;

        public Quantity(double amount, object unit)
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
            return this._unit == other._unit && 
                Math.Abs(this._amount - other._amount) < Tolerance;
        }

        public override int GetHashCode()
        {
            return _unit.GetHashCode() * 17 + _amount.GetHashCode();
        }
    }
}