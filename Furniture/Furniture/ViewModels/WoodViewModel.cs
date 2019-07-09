using Furniture.Materials;

namespace Furniture.ViewModels
{
    public sealed class WoodViewModel : MaterialViewModel
    {
        private readonly Material _material;
        private string _length = "1";
        private string _quantity = "1";
        private string _thickness = "1";
        private string _width = "1";

        public WoodViewModel(ItemViewModel sourceViewModel, Material material) : base(sourceViewModel)
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

        protected override void Update()
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

            ParentViewModel.Update();
        }
    }
}