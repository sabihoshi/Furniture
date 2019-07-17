using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Caliburn.Micro;
using Furniture.Relationship;
using Furniture.ViewModels.Materials;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Quotation
{
    public sealed class QuotationViewModel : Child, IParent
    {
        
        public QuotationViewModel(TableViewModel parent)
        {
            Parent = parent;

            var subTotal = new SubTotal();
            var tax = new Tax(subTotal);

            Quotations.Add(subTotal);
            Quotations.Add(tax);

            foreach (var work in Quotations) work.AddParent(this);

            OnPropertyChanged();
        }

        public new TableViewModel Parent { get; }

        public BindableCollection<Quotation> Quotations { get; set; } = App.Config.Work;

        public override void OnPropertyChanged(string propertyName = null)
        {
            CalculateQuotations(Quotations);
            base.OnPropertyChanged(propertyName);
        }

        public static void CalculateQuotations(BindableCollection<Quotation> quotations)
        {
            foreach (var quotation in quotations)
                quotation.Total = quotation.GetTotal();
        }

        public void Click(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            if (row?.DataContext is Quotation quotationRow)
            {
                // quotationRow.EditValues();
            }
        }

        public decimal? GetTotal(MaterialModel.Material material)
        {
            return Parent.GetTotal(material);
        }
    }
}