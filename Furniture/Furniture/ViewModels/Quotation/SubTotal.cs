using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture.ViewModels.Quotation
{
    public class SubTotal : Quotation
    {
        public override decimal? GetTotal()
        {
            return Parent?.Quotations.TakeWhile(x => x != this).Sum(x => x.Total);
        }

        public SubTotal() : base(nameof(SubTotal)) { }
    }
}
