/* 
 * Copyright (c) 2016 by Fred George
 * May be used freely except for training; license required for training.
 */
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoBootCamp
{
    // Understands a four-sided polygon with sides at right angles
    public class Rectangle
    {
        private readonly double _length;
        private readonly double _width;

        public Rectangle(double length, double width)
        {
            this._length = length;
            this._width = width;
        }
        
        public double Area()
        {
            return _length * _width;
        }

        public double Perimeter()
        {
            return 2*(_length + _width);
        }
    }
}
