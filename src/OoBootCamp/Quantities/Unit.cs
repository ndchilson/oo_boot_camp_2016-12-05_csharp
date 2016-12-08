/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp.Quantities
{
    // Understands a specific metric
    public class Unit
    {
        public static readonly Unit Teaspoon = new Unit();
        public static readonly Unit Tablespoon = new Unit(3, Teaspoon);
        public static readonly Unit Ounce = new Unit(2, Tablespoon);
        public static readonly Unit Cup = new Unit(8, Ounce);
        public static readonly Unit Pint = new Unit(2, Cup);
        public static readonly Unit Quart = new Unit(2, Pint);
        public static readonly Unit Gallon = new Unit(4, Quart);

        public static readonly Unit Inch = new Unit();
        public static readonly Unit Foot = new Unit(12, Inch);
        public static readonly Unit Yard = new Unit(3, Foot);
        public static readonly Unit Furlong = new Unit(220, Yard);
        public static readonly Unit Mile = new Unit(8, Furlong);

        private readonly Unit _baseUnit;
        private readonly double _baseUnitRatio;

        private Unit()
        {
            _baseUnit = this;
            _baseUnitRatio = 1.0;
        }

        private Unit(double relativeRatio, Unit relativeUnit)
        {
            _baseUnit = relativeUnit._baseUnit;
            _baseUnitRatio = relativeUnit._baseUnitRatio*relativeRatio;
        }

        protected internal double ConvertedAmount(double fromAmount, Unit other)
        {
            if (!this.IsCompatible(other)) throw new ArgumentException("Mixed unit arithmetic error");
            return fromAmount * other._baseUnitRatio / this._baseUnitRatio;
        }

        protected internal int Hash(double amount)
        {
            return (amount*_baseUnitRatio).GetHashCode();
        }

        public Quantity s(double amount)
        {
            return new Quantity(amount, this);
        }

        public Quantity es(double amount)
        {
            return this.s(amount);
        }

        public bool IsCompatible(Unit other)
        {
            return this._baseUnit == other._baseUnit;
        }
    }
}