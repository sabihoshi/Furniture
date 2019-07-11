using System.Collections.Generic;
using Furniture.ViewModels;

namespace Furniture.Quotation
{
    public class Value : Quotation
    {
        public Value(QuotationViewModel source) : base(source)
        {
        }

        public List<decimal> Values { get; set; }

        public override decimal Calculate(decimal wood, List<Quotation> input)
        {
            return Value;
        }
    }
}