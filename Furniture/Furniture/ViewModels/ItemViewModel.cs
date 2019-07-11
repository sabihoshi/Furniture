using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Caliburn.Micro;
using Furniture.Materials;
using Furniture.Properties;
using Furniture.Relationship;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged, IParent
    {
        private MaterialModel _content;
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

        public MaterialModel Content
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

        public BindableCollection<MaterialModel> Items { get; set; } = new BindableCollection<MaterialModel>();

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