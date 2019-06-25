using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using Fractions;
using Furniture.Models;

namespace Furniture.ViewModels
{
    public class PlywoodViewModel : INotifyPropertyChanged
    {
        private decimal _sliderValue;

        public PlywoodViewModel()
        {
            Plywood.Thicknesses.Add(new Thickness(0.25M, 450));
            Plywood.Thicknesses.Add(new Thickness(0.50M, 770));
            Plywood.Thicknesses.Add(new Thickness(0.75M, 1270));

            SliderValue = Plywood.Min.Percentage;
        }

        public Plywood Plywood { get; set; } = new Plywood();
        public decimal Price => Plywood.GetPrice(SliderValue) * Quantity;
        public string Ticks => string.Join(", ", Plywood.Thicknesses.Select(x => x.Percentage));
        public int Quantity { get; set; }

        public decimal SliderValue
        {
            get => _sliderValue;
            set
            {
                _sliderValue = value;
                Thickness = Fraction.FromDecimal(_sliderValue).ToString();
            }
        }

        public string Thickness { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}