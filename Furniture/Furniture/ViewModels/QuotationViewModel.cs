using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using Caliburn.Micro;
using Furniture.Properties;

namespace Furniture.ViewModels
{
    public class QuotationViewModel : INotifyPropertyChanged, IParent
    {
        
        private readonly TableViewModel _tableViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool EditVisibility { get; set; } = false;
        public QuotationEditViewModel EditValues { get; set; } = new QuotationEditViewModel();
        public QuotationViewModel(TableViewModel tableViewModel)
        {
            _tableViewModel = tableViewModel;
            foreach (var work in Work) work.AddViewModel(this);
            Update();
        }

        public BindableCollection<Quotation.Quotation> Work { get; set; } = App.Config.Work;

        public static void CalculateQuotations(BindableCollection<Quotation.Quotation> quotations, decimal woodTotal)
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

        public void Update()
        {
            CalculateQuotations(Work, _tableViewModel.WoodTotal);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}