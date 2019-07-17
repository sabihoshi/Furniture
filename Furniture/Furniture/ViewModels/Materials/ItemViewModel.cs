using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Furniture.Relationship;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Materials
{
    public class ItemViewModel : Child, IParent
    {
        private MaterialMasterViewModel _content;

        public MaterialModel.Material Type => Content.Type;

        public ItemViewModel(TableViewModel parent)
        {
            Parent = parent;
            Items.AddRange(new List<MaterialModel>(App.Config.Woods.Select(wood => new WoodViewModel(this, wood)))
            {
                new PlywoodViewModel(this),
                new FrameViewModel(this),
                new ConcealedViewModel(this),
                new HandleViewModel(this),
                new GlassViewModel(this),
                new NoneViewModel(this)
            }.ConvertModels());

            Content = Items.First();
        }

        public MaterialMasterViewModel Content
        {
            get => _content;
            set
            {
                if (value.Name == "None")
                {
                    (Parent as TableViewModel)?.RemoveItem(this);
                    return;
                }

                _content = value;
                OnPropertyChanged();
            }
        }

        public BindableCollection<MaterialMasterViewModel> Items { get; set; } = new BindableCollection<
            MaterialMasterViewModel>();
    }
}