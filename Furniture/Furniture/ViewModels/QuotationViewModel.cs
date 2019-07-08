using Furniture.Annotations;
using Furniture.Work;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caliburn.Micro;

namespace Furniture.ViewModels
{
    public class QuotationViewModel : INotifyPropertyChanged
    {
        private readonly TableViewModel _tableViewModel;
        private BindingList<ICanCalculate> _work = App.Config.Work;

        public event PropertyChangedEventHandler PropertyChanged;

        public QuotationViewModel(TableViewModel tableViewModel)
        {
            _tableViewModel = tableViewModel;
            Update();
        }

        public BindingList<ICanCalculate> Work
        {
            get => _work;
            set
            {
                _work = value;
                OnPropertyChanged(nameof(Work));
            }
        }

        public void Update()
        {
            Work = App.Config.Work.CalculateQuotations(_tableViewModel.WoodTotal);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}