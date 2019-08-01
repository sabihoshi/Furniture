namespace Furniture.ViewModels.Quotation
{
    public class Total : Quotation
    {
        private readonly VatAble _vatAble;
        private readonly Vat _vat;

        public Total(VatAble vatAble, Vat vat) : base(nameof(Total))
        {
            _vatAble = vatAble;
            _vat = vat;
        }

        public override decimal? GetTotal()
        {
            return _vatAble.Total + _vat.Total;
        }
    }
}