using Furniture.Materials;
using Furniture.Properties;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Furniture.ViewModels
{
    public sealed class MaterialViewModel : ChildViewModel, INotifyPropertyChanged
    {
        private readonly Material _material;
        private string _length = "1";
        private string _quantity = "1";
        private string _thickness = "1";
        private string _width = "1";

        public event PropertyChangedEventHandler PropertyChanged;

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
                Update();
            }
        }

        public override string Name => _material.Name;

        public string Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                Update();
            }
        }

        public string Thickness
        {
            get => _thickness;
            set
            {
                _thickness = value;
                Update();
            }
        }

        public override decimal Total { get; set; }

        public string Width
        {
            get => _width;
            set
            {
                _width = value;
                Update();
            }
        }

        public override void Update()
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

            _sourceViewModel.Update();
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}