using System;
using System.Collections.Generic;
using System.Linq;

namespace Furniture.Models
{
    public class Plywood
    {
        public Plywood()
        {
            Thicknesses = App.Config.Materials.Single(x => x.Name == nameof(Plywood)).Thicknesses;
        }

        public Thickness Max => Thicknesses.OrderByDescending(x => x.Value).First();
        public Thickness Min => Thicknesses.OrderByDescending(x => x.Value).Last();
        public List<Thickness> Thicknesses { get; set; }

        public decimal GetPrice(decimal thickness)
        {
            if (thickness > Max.Value)
                return Max.Price;
            if (thickness < Min.Value)
                return Min.Price;

            var result = Thicknesses.FirstOrDefault(x => x.Value == thickness);
            if (result != null)
                return result.Price;

            var thicknesses = Thicknesses.OrderBy(x => x.Value).ToList();

            for (var i = 0; i < thicknesses.Count; i++)
            {
                if (thickness > thicknesses[i].Value)
                {
                    var inputs = thicknesses.Skip(i).Take(2).ToArray();
                    var line = Line.GetLineBetweenTwoPoints(inputs.First(), inputs.Last());
                    return line.GetValue(thickness);
                }
            }

            throw new InvalidOperationException("Could not find price for thickness");
        }
    }
}