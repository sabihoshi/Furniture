using System.Linq;

namespace Furniture.ViewModels.Quotation
{
    public class SubTotal : Quotation
    {
        public SubTotal() : base(nameof(SubTotal)) { }

        public override decimal? GetTotal()
        {
            return Parent?.Quotations.TakeWhile(x => x != this).Sum(x => x.Total);
        }
    }
}