using System.Collections.Generic;
using System.Linq;

namespace Furniture.Work
{
    public class QuotationValue : ICanCalculate
    {
        public string Name { get; set; }
        public decimal Total { get; set; }
        public decimal Value { get; set; }

        public decimal Calculate(decimal wood, List<ICanCalculate> input)
        {
            return Value;
        }
    }
}