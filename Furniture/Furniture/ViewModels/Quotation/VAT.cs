namespace Furniture.ViewModels.Quotation
{
    public class Vat : Quotation
    {
        private readonly VatAble _vatAble;

        public Vat(VatAble vatAble) : base("VAT", 0.12m)
        {
            _vatAble = vatAble;
        }

        public override decimal? GetTotal()
        {
            return _vatAble.Total * Value;
        }
    }
}