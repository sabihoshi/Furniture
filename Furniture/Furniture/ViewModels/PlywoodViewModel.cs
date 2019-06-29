using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Fractions;
using Furniture.Models;

namespace Furniture.ViewModels
{
    public class PlywoodViewModel : IMaterial, INotifyPropertyChanged
    {
        private int _quantity;
        private string _quantityField;
        private decimal _sliderValue;
        private readonly ItemViewModel _sourceViewModel;

        public PlywoodViewModel(ItemViewModel sourceViewModel)
        {
            _sourceViewModel = sourceViewModel;
            SliderValue = Plywood.Min.Value;
        }

        public string Name => "Plywood";

        public Plywood Plywood { get; set; } = new Plywood();

        public decimal Price { get; set; }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                UpdatePrice();
            }
        }

        private void UpdatePrice()
        {
            Price = Plywood.GetPrice(SliderValue) * Quantity;
            _sourceViewModel.UpdatePrice();
        }

        public string QuantityField
        {
            get => _quantityField;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _quantityField = "0";
                    Quantity = 0;
                }
                else if (int.TryParse(value, out var result))
                {
                    _quantityField = result.ToString();
                    Quantity = result;
                }
            }
        }

        public decimal SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                Thickness = Fraction.FromDecimal(_sliderValue).ToString();
                Price = Plywood.GetPrice(SliderValue) * Quantity;
            }
        }

        public string Thickness { get; set; }
        public string Ticks => string.Join(", ", Plywood.Thicknesses.Select(x => x.Value));

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}