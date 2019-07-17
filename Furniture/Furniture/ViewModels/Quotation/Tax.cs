namespace Furniture.ViewModels.Quotation
{
    public class Tax : Quotation
    {
        private readonly SubTotal _subTotal;

        public Tax(SubTotal subTotal) : base(nameof(Tax))
        {
            _subTotal = subTotal;
        }

        public override decimal? GetTotal()
        {
            return _subTotal.Total * Value;
        }
    }
}