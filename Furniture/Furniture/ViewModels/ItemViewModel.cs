using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Furniture.Models;
using Furniture.Properties;
using PropertyChanged;

namespace Furniture.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private readonly TableViewModel _sourceViewModel;
        private IMaterial _content;
        private decimal _total;

        public ItemViewModel(TableViewModel sourceViewModel)
        {
            _sourceViewModel = sourceViewModel;
            
            Items.Add(new NoneViewModel());
            Items.Add(new PlywoodViewModel(this));
        }

        public IMaterial Content
        {
            get => _content;
            set
            {
                if (value.Name == "None")
                {
                    _sourceViewModel.RemoveItem(this);
                    return;
                }
                _content = value;
            }
        }

        public void UpdatePrice()
        {
            _sourceViewModel.UpdatePrice();
        }


        public BindableCollection<IMaterial> Items { get; set; } = new BindableCollection<IMaterial>();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
