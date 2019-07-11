using System.Collections.Generic;
using Furniture.Materials;

namespace Furniture.ViewModels
{
    public sealed class PlywoodViewModel : MaterialViewModel, IParent
    {
        private string _quantity = "1";

        private Thickness _selectedThickness;

        public List<CaptionViewModel> Fields { get; set; }

        public PlywoodViewModel(IParent parentModel) : base(parentModel)
        {
            Fields = new List<CaptionViewModel>
            {
                new CaptionViewModel(this, "Thickness", new ComboBoxViewModel(this)),
                new CaptionViewModel(this, "Quantity", new TextBoxViewModel(this))
            };
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
            get =>
                _selectedThickness;
            set
            {
                _selectedThickness = value;
                Update();
            }
        }

        public override decimal Total { get; set; }

        public override void Update()
        {
            if (!int.TryParse(Quantity, out var quantity))
                return;

            Total = SelectedThickness.Price * quantity;

            Parent.Update();
        }
    }
}