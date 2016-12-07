/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */

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

        private readonly double _baseUnitRatio;

        private Unit()
        {
            _baseUnitRatio = 1.0;
        }

        private Unit(double relativeRatio, Unit relativeUnit)
        {
            _baseUnitRatio = relativeUnit._baseUnitRatio*relativeRatio;
        }

        protected internal double ConvertedAmount(double fromAmount, Unit other)
        {
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
    }
}