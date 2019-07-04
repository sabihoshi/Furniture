using System.ComponentModel;
using System.Runtime.CompilerServices;
using Furniture.Materials;

namespace Furniture.ViewModels
{
    public sealed class PlywoodViewModel : ChildModel, INotifyPropertyChanged
    {
        private string _quantity = "1";

        private Thickness _selectedThickness = Plywood.Min;

        public PlywoodViewModel(ItemViewModel sourceViewModel) : base(sourceViewModel) { }

        public override string Name => "Plywood";

        public static Plywood Plywood { get; set; } = App.Config.Plywood;

        public string Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                UpdatePrice();
            }
        }

        public Thickness SelectedThickness
        {
            get => _selectedThickness;
            set
            {
                _selectedThickness = value;
                UpdatePrice();
            }
        }

        public override decimal Total { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void UpdatePrice()
        {
            if (!int.TryParse(Quantity, out var quantity))
                return;

            Total = SelectedThickness.Price * quantity;

            _sourceViewModel.UpdatePrice();
        }
    }
}