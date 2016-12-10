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
        public static readonly RatioUnit Teaspoon = new RatioUnit();
        public static readonly RatioUnit Tablespoon = new RatioUnit(3, Teaspoon);
        public static readonly RatioUnit Ounce = new RatioUnit(2, Tablespoon);
        public static readonly RatioUnit Cup = new RatioUnit(8, Ounce);
        public static readonly RatioUnit Pint = new RatioUnit(2, Cup);
        public static readonly RatioUnit Quart = new RatioUnit(2, Pint);
        public static readonly RatioUnit Gallon = new RatioUnit(4, Quart);

        public static readonly RatioUnit Inch = new RatioUnit();
        public static readonly RatioUnit Foot = new RatioUnit(12, Inch);
        public static readonly RatioUnit Yard = new RatioUnit(3, Foot);
        public static readonly RatioUnit Furlong = new RatioUnit(220, Yard);
        public static readonly RatioUnit Mile = new RatioUnit(8, Furlong);

        public static readonly IntervalUnit Celsius = new IntervalUnit();
        public static readonly IntervalUnit Fahrenheit = new IntervalUnit(5 / 9.0, 32, Celsius);

        private readonly Unit _baseUnit;
        private readonly double _baseUnitRatio;
        private readonly double _offset;

        protected internal Unit()
        {
            _baseUnit = this;
            _baseUnitRatio = 1.0;
            _offset = 0.0;
        }

        protected internal Unit(double relativeRatio, double offset, Unit relativeUnit)
        {
            _baseUnit = relativeUnit._baseUnit;
            _baseUnitRatio = relativeUnit._baseUnitRatio * relativeRatio;
            _offset = offset;
        }

        protected internal double ConvertedAmount(double fromAmount, Unit other)
        {
            if (!this.IsCompatible(other)) throw new ArgumentException("Mixed unit arithmetic error");
            return (fromAmount - other._offset) * other._baseUnitRatio / this._baseUnitRatio + this._offset;
        }

        protected internal int Hash(double amount)
        {
            return (amount * _baseUnitRatio).GetHashCode();
        }

        public bool IsCompatible(Unit other)
        {
            return this._baseUnit == other._baseUnit;
        }

        public class IntervalUnit : Unit
        {
            internal IntervalUnit()
            {
            }

            internal IntervalUnit(double relativeRatio, double offset, Unit relativeUnit) 
                : base(relativeRatio, offset, relativeUnit)
            {
            }

            public IntervalQuantity S(double amount)
            {
                return new IntervalQuantity(amount, this);
            }

            public IntervalQuantity Es(double amount)
            {
                return this.S(amount);
            }
        }

        public class RatioUnit : Unit
        {

            internal RatioUnit()
            {
            }

            internal RatioUnit(double relativeRatio, Unit relativeUnit) 
                : base(relativeRatio, 0.0, relativeUnit)
            {
            }

            public RatioQuantity S(double amount)
            {
                return new RatioQuantity(amount, this);
            }

            public RatioQuantity Es(double amount)
            {
                return this.S(amount);
            }
        }

    }
}