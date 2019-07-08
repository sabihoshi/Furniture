using System.Collections.Generic;
using System.Linq;
using Fractions;

namespace Furniture.Work
{
    public class QuotationPercentage : ICanCalculate
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
        public decimal Value { get; set; }
        public decimal Calculate(decimal wood, List<ICanCalculate> input)
        {
            return Value * (input.Select(x => x.Total).Sum() + wood);
        }
    }
}