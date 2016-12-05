/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
 using System;

namespace OoBootCamp
{
    // Understands a four-sided polygon with sides at right angles
    public class Rectangle
    {
        private readonly double _length;
        private readonly double _width;

        public Rectangle(double length, double width)
        {
            if (length <= 0.0 || width <= 0.0) throw new ArgumentException("Range error");
            _length = length;
            _width = width;
        }
        
        public double Area() => _length * _width;

        public double Perimeter() => 2*(_length + _width);
    }
}
