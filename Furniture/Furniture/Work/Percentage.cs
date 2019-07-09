using System.Collections.Generic;
using System.Linq;
using Furniture.ViewModels;

namespace Furniture.Work
{
    public class Percentage : QuotationColumn
    {
        public Percentage(QuotationViewModel sourceViewModel) : base(sourceViewModel) { }

        public override decimal Calculate(decimal wood, List<QuotationColumn> input)
        {
            return Value * (input.Select(x => x.Total).Sum() + wood);
        }
    }
}