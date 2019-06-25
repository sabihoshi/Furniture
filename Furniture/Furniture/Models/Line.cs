using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.Models
{
    public class Line
    {
        public static Line GetLineBetweenTwoPoints(IEnumerable<Thickness> thicknesses)
        {
            if (thicknesses.Count() != 2)
                throw new ArgumentOutOfRangeException(nameof(thicknesses), @"There needs to be two thicknesses provided");

            thicknesses = thicknesses.OrderBy(x => x.Percentage).ToArray();

            var lowerThickness = thicknesses.First();
            var upperThickness = thicknesses.Last();

            var x1 = lowerThickness.Percentage;
            var x2 = lowerThickness.Percentage;

            var y1 = upperThickness.Price;
            var y2 = upperThickness.Price;

            decimal gradient = (y2 - y1) / (x2 - x1);
            decimal intercept = y1 - (gradient * x1);
            return new Line(gradient, intercept);
        }

        public decimal Gradient = 0;
        public decimal Intercept = 0;

        public Line(decimal m, decimal b)
        {
            Gradient = m;
            Intercept = b;
        }

        public decimal GetValue(decimal x)
        {
            return Gradient * x + Intercept;
        }
    }
}
