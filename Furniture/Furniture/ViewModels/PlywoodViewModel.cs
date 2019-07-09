using Furniture.Materials;
using Furniture.Work;

namespace Furniture.ViewModels
{
    public sealed class PlywoodViewModel : MaterialViewModel
    {
        private string _quantity = "1";

        private Thickness _selectedThickness;

        public PlywoodViewModel(IParentViewModel parentViewModelModel) : base(parentViewModelModel)
        {
            _selectedThickness = Plywood.Min;
        }

        public override string Name => "Plywood";

        public Plywood Plywood { get; set; } = App.Config.Plywood;

        public string Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                Update();
            }
        }

        public Thickness SelectedThickness
        {
            get => _selectedThickness;
            set
            {
                _selectedThickness = value;
                Update();
            }
        }

        public override decimal Total { get; set; }

        protected override void Update()
        {
            if (!int.TryParse(Quantity, out var quantity))
                return;

            Total = SelectedThickness.Price * quantity;

            ParentViewModel.Update();
        }
    }
}