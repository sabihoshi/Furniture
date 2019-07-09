using Furniture.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Furniture.Work
{
    public class QuotationPercentage : HasCalculation
    {
        public QuotationPercentage(QuotationViewModel sourceViewModel) : base(sourceViewModel)
        {
        }

        public override decimal Calculate(decimal wood, List<HasCalculation> input)
        {
            return Value * (input.Select(x => x.Total).Sum() + wood);
        }
    }
}