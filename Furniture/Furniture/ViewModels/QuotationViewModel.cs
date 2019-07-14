using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;
using Furniture.Properties;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public sealed class QuotationViewModel : Parent
    {
        private readonly TableViewModel _tableViewModel;

        public QuotationViewModel(TableViewModel tableViewModel)
        {
            _tableViewModel = tableViewModel;
            foreach (var work in Work) work.AddParent(this);
            OnPropertyChanged();
        }

        public QuotationEditViewModel EditValues { get; set; } = new QuotationEditViewModel();
        public bool EditVisibility { get; set; } = false;
        public BindableCollection<Quotation.Quotation> Work { get; set; } = App.Config.Work;

        public static void CalculateQuotations(BindableCollection<Quotation.Quotation> quotations, decimal? woodTotal)
        {
            var total = woodTotal;

            for (var i = 0; i < quotations.Count; i++)
            {
                var quotation = quotations[i];
                quotation.Total = quotation.Calculate(total, quotations.Take(i).ToList());
            }
        }

        public void Click(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            if (row?.DataContext is Quotation.Quotation quotationRow)
            {
                quotationRow.EditValues();
            }
        }

        [NotifyPropertyChangedInvocator]
        public override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            CalculateQuotations(Work, _tableViewModel.WoodTotal);
            base.OnPropertyChanged(propertyName);
        }
    }
}