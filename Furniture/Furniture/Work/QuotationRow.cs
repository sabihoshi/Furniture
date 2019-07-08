using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;

namespace Furniture.Work
{
    public static class QuotationRow
    {
        public static BindingList<ICanCalculate> CalculateQuotations(this BindingList<ICanCalculate> quotations, decimal woodTotal)
        {
            var total = woodTotal;

            for (var i = 0; i < quotations.Count; i++)
            {
                var quotation = quotations[i];
                quotation.Total = quotation.Calculate(total, quotations.Take(i).ToList());
            }

            return quotations;
        }
    }
}