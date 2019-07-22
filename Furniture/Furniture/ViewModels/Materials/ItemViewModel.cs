using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Furniture.Relationship;
using IParent = Furniture.Relationship.IParent;

namespace Furniture.ViewModels.Materials
{
    public class ItemViewModel : Child, IParent, IDisposable
    {
        private bool _disposed = false;
        public ItemViewModel(TableViewModel parent) : base(parent)
        {
            Parent = parent;

            Items.AddRange(new List<MaterialBase>(App.Config.Woods.Select(wood => new WoodViewModel(this, wood)))
            {
                new PlywoodViewModel(this),
                new FrameViewModel(this),
                new ConcealedViewModel(this),
                new HandleViewModel(this),
                new GlassViewModel(this),
                new NoneViewModel(this)
            }.ConvertToModels());

            Content = Items.First();

            Parent.WoodCreated += OnWoodCreated;
        }

        public new TableViewModel Parent { get; set; }
        ~ItemViewModel() => Dispose(false);

        void IDisposable.Dispose() => Dispose(true);

        private void OnWoodCreated(TableViewModel sender, Wood e)
        {
            var model = new WoodViewModel(this, e);
            Items.Add(model.ConvertToModel());
        }

        public MaterialViewModel Content { get; set; }

        public BindableCollection<MaterialViewModel> Items { get; set; } = new BindableCollection<MaterialViewModel>();

        public MaterialBase.Material Type => Content.Type;

        public override void OnPropertyChanged(string propertyName = null)
        {
            if (Content?.Name == "None")
            {
                Parent.RemoveItem(this);
                Dispose(true);
                return;
            }
            base.OnPropertyChanged(propertyName);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                Parent.WoodCreated -= OnWoodCreated;
                _disposed = true;
            }
        }
    }
}