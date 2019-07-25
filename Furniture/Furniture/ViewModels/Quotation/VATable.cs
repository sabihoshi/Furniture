using System.Linq;

namespace Furniture.ViewModels.Quotation
{
    public class VatAble : Quotation
    {
        public VatAble() : base("Non-VAT") { }

        public override decimal? GetTotal()
        {
            return Parent?.Quotations.TakeWhile(x => x != this).Sum(x => x.Total);
        }
    }
}