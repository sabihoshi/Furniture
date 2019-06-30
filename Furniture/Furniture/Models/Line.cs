using System;
using System.Collections.Generic;
using System.Linq;

namespace Furniture.Models
{
    public class Line
    {
        private readonly decimal _gradient;
        private readonly decimal _intercept;

        private Line(decimal gradient, decimal intercept)
        {
            _gradient = gradient;
            _intercept = intercept;
        }

        public static Line GetLineBetweenTwoPoints(Thickness lowerThickness, Thickness upperThickness)
        {
            var x1 = lowerThickness.Value;
            var x2 = lowerThickness.Value;

            var y1 = upperThickness.Price;
            var y2 = upperThickness.Price;

            var price = y2 - y1;
            var value = x2 - x1;

            if (value == 0)
                return new Line(0, 0);

            var gradient = price / value;
            var intercept = y1 - gradient * x1;
            return new Line(gradient, intercept);
        }

        public decimal GetValue(decimal x)
        {
            return _gradient * x + _intercept;
        }
    }
}