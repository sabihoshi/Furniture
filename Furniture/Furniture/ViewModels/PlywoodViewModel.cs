using System.ComponentModel;
using System.Runtime.CompilerServices;
using Furniture.Materials;

namespace Furniture.ViewModels
{
    public sealed class PlywoodViewModel : ChildViewModel, INotifyPropertyChanged
    {
        private string _quantity = "1";

        private Thickness _selectedThickness;

        public PlywoodViewModel(ItemViewModel sourceViewModel) : base(sourceViewModel)
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void Update()
        {
            if (!int.TryParse(Quantity, out var quantity))
                return;

            Total = SelectedThickness.Price * quantity;

            _sourceViewModel.Update();
        }
    }
}