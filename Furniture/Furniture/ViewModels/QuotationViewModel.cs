using Caliburn.Micro;
using Furniture.Work;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Furniture.Properties;

namespace Furniture.ViewModels
{
    public class QuotationViewModel : INotifyPropertyChanged, IParentViewModel
    {
        private readonly TableViewModel _tableViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public QuotationViewModel(TableViewModel tableViewModel)
        {
            _tableViewModel = tableViewModel;
            foreach (var work in Work) { work.AddViewModel(this); }
            Update();
        }

        public BindableCollection<HasCalculation> Work { get; set; } = App.Config.Work;

        public void Update()
        {
            Work.CalculateQuotations(_tableViewModel.WoodTotal);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}