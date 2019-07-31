using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using Furniture.Relationship;
using Furniture.ViewModels.Materials.Items;
using Furniture.ViewModels.Materials.Models;
using IParent = Furniture.Relationship.IParent;
using PieceItem = Furniture.ViewModels.Materials.Items.PieceItem;

namespace Furniture.ViewModels.Materials
{
    public class ItemViewModel : Child, IParent, IDisposable
    {
        private bool _disposed = false;
        public ItemViewModel(TableViewModel parent) : base(parent)
        {
            Parent = parent;

            Items.AddRange(
                App.Config.Woods
                   .Select(cuboid => new WoodItem(this, cuboid))
                   .ConvertToModels());

            Items.AddRange(
                App.Config.Pieces
                    .Select(piece => new PieceItem(this, piece))
                    .ConvertToModels());

            Items.AddRange(new List<MaterialBase>
            {
                new FoamItem(this),
                new PlywoodItem(this),
                new NoneItem(this)
            }.ConvertToModels());

            Content = Items.FirstOrDefault();

            Parent.WoodCreated += OnWoodCreated;
        }

        public new TableViewModel Parent { get; set; }
        ~ItemViewModel() => Dispose(false);

        void IDisposable.Dispose() => Dispose(true);

        private void OnWoodCreated(TableViewModel sender, Wood e)
        {
            var model = new WoodItem(this, e);
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