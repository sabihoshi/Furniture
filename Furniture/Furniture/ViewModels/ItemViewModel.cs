using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Caliburn.Micro;
using Furniture.Properties;

namespace Furniture.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private ChildModel _content;
        private readonly TableViewModel _sourceViewModel;

        public ItemViewModel(TableViewModel sourceViewModel)
        {
            _sourceViewModel = sourceViewModel;

            Items.Add(new PlywoodViewModel(this));

            foreach (var material in App.Config.Materials)
                Items.Add(new MaterialViewModel(this, material));

            Items.Add(new NoneViewModel(this));

            Content = Items.First();
        }

        public ChildModel Content
        {
            get => _content;
            set
            {
                if (value.Name == "None")
                {
                    _sourceViewModel.RemoveItem(this);
                    UpdatePrice();
                    return;
                }

                _content = value;
                UpdatePrice();
            }
        }

        public BindableCollection<ChildModel> Items { get; set; } = new BindableCollection<ChildModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdatePrice()
        {
            _sourceViewModel.UpdatePrice();
        }
    }
}