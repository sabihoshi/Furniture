using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Caliburn.Micro;
using Furniture.Properties;

namespace Furniture.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private ChildViewModel _content;
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

        public ChildViewModel Content
        {
            get => _content;
            set
            {
                if (value.Name == "None")
                {
                    _sourceViewModel.RemoveItem(this);
                    Update();
                    return;
                }

                _content = value;
                Update();
            }
        }

        public BindableCollection<ChildViewModel> Items { get; set; } = new BindableCollection<ChildViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Update()
        {
            _sourceViewModel.Update();
        }
    }
}