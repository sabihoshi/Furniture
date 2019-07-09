using Furniture.Annotations;
using Furniture.Work;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Caliburn.Micro;

namespace Furniture.ViewModels
{
    public class QuotationViewModel : INotifyPropertyChanged
    {
        private readonly TableViewModel _tableViewModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public QuotationViewModel(TableViewModel tableViewModel)
        {
            _tableViewModel = tableViewModel;
            Update();
        }

        public BindableCollection<ICanCalculate> Work { get; set; } = App.Config.Work;

        public void Update()
        {
            Work.CalculateQuotations(_tableViewModel.WoodTotal);
            Work.Add(new QuotationPercentage());
            Work.Remove(Work.Last());
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}