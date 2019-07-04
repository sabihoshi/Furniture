using System.ComponentModel;
using System.Runtime.CompilerServices;
using Furniture.Materials;
using Furniture.Properties;

namespace Furniture.ViewModels
{
    public sealed class MaterialViewModel : ChildModel, INotifyPropertyChanged
    {
        private string _length = "1";

        private readonly Material _material;
        private string _quantity = "1";
        private string _thickness = "1";
        private string _width = "1";

        public MaterialViewModel(ItemViewModel sourceViewModel, Material material) : base(sourceViewModel)
        {
            _material = material;
        }

        public string Length
        {
            get => _length;
            set
            {
                _length = value;
                UpdatePrice();
            }
        }

        public override string Name => _material.Name;

        public string Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                UpdatePrice();
            }
        }

        public string Thickness
        {
            get => _thickness;
            set
            {
                _thickness = value;
                UpdatePrice();
            }
        }

        public override decimal Total { get; set; }

        public string Width
        {
            get => _width;
            set
            {
                _width = value;
                UpdatePrice();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void UpdatePrice()
        {
            if (!int.TryParse(Thickness, out var thickness))
                return;
            if (!int.TryParse(Width, out var width))
                return;
            if (!int.TryParse(Length, out var length))
                return;
            if (!int.TryParse(Quantity, out var quantity))
                return;

            var slice = thickness * width * length / 12m;

            Total = slice * _material.Price * quantity;

            _sourceViewModel.UpdatePrice();
        }
    }
}