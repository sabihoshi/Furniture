using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Furniture.Properties;
using Furniture.ViewModels;

namespace Furniture.Work
{
    public abstract class HasCalculation : ChildViewModel, INotifyPropertyChanged
    {
        private decimal _value;

        public event PropertyChangedEventHandler PropertyChanged;

        protected HasCalculation(IParentViewModel parentViewModel) : base(parentViewModel)
        {
        }

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

        public abstract decimal Calculate(decimal wood, List<HasCalculation> input);

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}