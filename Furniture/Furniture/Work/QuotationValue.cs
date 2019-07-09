using Furniture.ViewModels;
using System.Collections.Generic;

namespace Furniture.Work
{
    public class QuotationValue : HasCalculation
    {
        public QuotationValue(QuotationViewModel sourceViewModel) : base(sourceViewModel)
        {
        }

        public override decimal Calculate(decimal wood, List<HasCalculation> input)
        {
            return Value;
        }
    }
}