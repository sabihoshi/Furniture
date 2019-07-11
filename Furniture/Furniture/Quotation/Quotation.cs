using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Windows;
using Caliburn.Micro;
using Furniture.Properties;
using Furniture.ViewModels;
using Newtonsoft.Json;
using IParent = Furniture.ViewModels.IParent;

namespace Furniture.Quotation
{
    public abstract class Quotation : ChildViewModel, INotifyPropertyChanged
    {
        private decimal _value;

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IWindowManager _manager = new WindowManager();
        protected Quotation(IParent parent) : base(parent)
        {
        }

        public void EditValues()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.Height = 600;
            settings.Width = 300;
            settings.SizeToContent = SizeToContent.Manual;
            settings.ResizeMode = ResizeMode.NoResize;
            // settings.WindowStyle = WindowStyle.None;

            _manager.ShowDialog(new QuotationEditViewModel(), settings: settings);
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

        public abstract decimal Calculate(decimal wood, List<Quotation> input);

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}