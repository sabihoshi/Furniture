using System.Collections.Generic;
using System.Linq;
using Furniture.Materials;

namespace Furniture.Work
{
    public class Work
    {
        public List<ICanCalculate> Areas { get; set; } =
            new List<ICanCalculate>
            {
                new Area("Finishing", 0.45m),
                new Area("Overhead", 0.35m),
                new Area("Office", 0.25m),
                new Area("Store", 0.15m)
            };

        public Fee Labor { get; set; }

        public Area Milling { get; set; }

        public List<Wood> Woods { get; set; } = new List<Wood>();

        public void AddWood(Wood wood)
        {
            Woods.Add(wood);
            GetTotal();
        }

        public decimal AreaCalculation(List<ICanCalculate> calculates, decimal total)
        {
            foreach (var calculate in calculates)
                total += calculate.Calculate(total);

            return total;
        }

        public decimal GetTotal()
        {
            // Calculate the total of the wood
            var woodTotal = Woods.Select(wood => wood.Price).Sum();

            // Calculate milling
            Milling.Calculate(woodTotal);

            // Calculate areas
            return AreaCalculation(Areas, woodTotal);
        }
    }
}