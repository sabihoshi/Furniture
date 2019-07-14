using System.Collections.Generic;
using System.Linq;
using Furniture.ViewModels;

namespace Furniture.Quotation
{
    public class Percentage : Quotation
    {
        public override decimal? Calculate(decimal? wood, List<Quotation> input)
        {
            return Value * (input.Select(x => x.Total).Sum() + wood);
        }
    }
}