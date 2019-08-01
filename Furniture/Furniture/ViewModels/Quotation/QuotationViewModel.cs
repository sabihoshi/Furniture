using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;
using Furniture.Relationship;
using Furniture.ViewModels.Materials.Items;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Quotation
{
    public sealed class QuotationViewModel : Child, IParent
    {
        public QuotationViewModel(TableViewModel parent)
        {
            Parent = parent;

            var subTotal = new VatAble();
            var tax = new Vat(subTotal);
            var total = new Total(subTotal, tax);

            Quotations.Add(subTotal);
            Quotations.Add(tax);
            Total = total;

            foreach (var work in Quotations) work.AddParent(this);
        }

        public Quotation Total { get; }

        public new TableViewModel Parent { get; }

        public BindableCollection<Quotation> Quotations { get; set; } = App.Config.Work;

        public override void OnPropertyChanged(string propertyName = null)
        {
            CalculateQuotations(Quotations);
            base.OnPropertyChanged(propertyName);
        }

        public void CalculateQuotations(BindableCollection<Quotation> quotations)
        {
            foreach (var quotation in quotations)
                quotation.Total = quotation.GetTotal();
            Total.Total = Total.GetTotal();
        }

        public void Click(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            if (row?.DataContext is Quotation quotationRow)
            {
                // quotationRow.EditValues();
            }
        }

        public decimal? GetTotal(MaterialBase.Material material)
        {
            return Parent.GetTotal(material);
        }
    }
}