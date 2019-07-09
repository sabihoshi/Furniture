using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caliburn.Micro;
using Furniture.Properties;
using Furniture.Work;

namespace Furniture.ViewModels
{
    public class QuotationViewModel : INotifyPropertyChanged, IParentViewModel
    {
        private readonly TableViewModel _tableViewModel;

        public QuotationViewModel(TableViewModel tableViewModel)
        {
            _tableViewModel = tableViewModel;
            foreach (var work in Work) work.AddViewModel(this);
            Update();
        }

        public BindableCollection<QuotationColumn> Work { get; set; } = App.Config.Work;

        public event PropertyChangedEventHandler PropertyChanged;

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