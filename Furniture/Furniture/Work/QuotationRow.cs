using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Caliburn.Micro;

namespace Furniture.Work
{
    public static class QuotationRow
    {
        public static void CalculateQuotations(this BindableCollection<QuotationColumn> quotations, decimal woodTotal)
        {
            var total = woodTotal;

            for (var i = 0; i < quotations.Count; i++)
            {
                var quotation = quotations[i];
                quotation.Total = quotation.Calculate(total, quotations.Take(i).ToList());
            }
        }
    }
}