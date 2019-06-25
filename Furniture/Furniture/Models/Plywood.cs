using System;
using System.Collections.Generic;
using System.Linq;

namespace Furniture.Models
{
    public class Plywood
    {
        public Thickness Max => Thicknesses.OrderByDescending(x => x.Percentage).First();
        public Thickness Min => Thicknesses.OrderByDescending(x => x.Percentage).Last();
        public List<Thickness> Thicknesses { get; set; } = new List<Thickness>();

        public decimal GetPrice(decimal thickness)
        {
            if (thickness > Max.Percentage)
                return Max.Price;
            if (thickness < Min.Percentage)
                return Min.Price;

            var result = Thicknesses.FirstOrDefault(x => x.Percentage == thickness);
            if (result != null)
                return result.Price;

            var thicknesses = Thicknesses.OrderBy(x => x.Percentage).ToList();

            for (var i = 0; i < thicknesses.Count; i++)
                if (thickness > thicknesses[i].Percentage)
                {
                    var line = Line.GetLineBetweenTwoPoints(thicknesses.Skip(i).Take(2));
                    return line.GetValue(thickness);
                }

            throw new InvalidOperationException("Could not find price for thickness");
        }
    }
}