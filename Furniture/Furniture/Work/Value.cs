using System.Collections.Generic;
using Furniture.ViewModels;

namespace Furniture.Work
{
    public class Value : QuotationColumn
    {
        public Value(QuotationViewModel sourceViewModel) : base(sourceViewModel) { }

        public override decimal Calculate(decimal wood, List<QuotationColumn> input)
        {
            return Value;
        }
    }
}