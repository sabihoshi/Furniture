using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Caliburn.Micro;
using Furniture.Properties;

namespace Furniture.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged, IParentViewModel
    {
        private MaterialViewModel _content;
        private readonly TableViewModel _sourceViewModel;

        public ItemViewModel(TableViewModel sourceViewModel)
        {
            _sourceViewModel = sourceViewModel;

            Items.Add(new PlywoodViewModel(this));

            foreach (var material in App.Config.Materials)
                Items.Add(new WoodViewModel(this, material));

            Items.Add(new NoneViewModel(this));

            Content = Items.First();
        }

        public MaterialViewModel Content
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

        public BindableCollection<MaterialViewModel> Items { get; set; } = new BindableCollection<MaterialViewModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void Update()
        {
            _sourceViewModel.Update();
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}