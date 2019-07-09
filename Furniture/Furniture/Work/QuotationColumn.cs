using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Furniture.Properties;
using Furniture.ViewModels;
using Newtonsoft.Json;

namespace Furniture.Work
{
    public abstract class QuotationColumn : ChildViewModel, INotifyPropertyChanged
    {
        private decimal _value;

        protected QuotationColumn(IParentViewModel parentViewModel) : base(parentViewModel) { }

        public string Name { get; set; }

        [JsonIgnore] public decimal Total { get; set; }

        public decimal Value
        {
            get => _value;
            set
            {
                if (value == _value) return;
                _value = value;
                Update();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract decimal Calculate(decimal wood, List<QuotationColumn> input);

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}