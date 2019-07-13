using System.Linq;
using Caliburn.Micro;
using Furniture.Materials;
using Furniture.Relationship;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels
{
    public class ItemViewModel : Child, IParent
    {
        private readonly TableViewModel _sourceViewModel;
        private MaterialModel _content;

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
                    OnPropertyChanged();
                    return;
                }

                _content = value;
                OnPropertyChanged();
            }
        }

        public BindableCollection<MaterialModel> Items { get; set; } = new BindableCollection<MaterialModel>();
    }
}