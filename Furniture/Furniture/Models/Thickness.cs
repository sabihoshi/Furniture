using System.Collections.Generic;
using Fractions;

namespace Furniture.Models
{
    public class Thickness
    {
        private decimal _value;

        public decimal Value
        {
            get => _value;
            set
            {
                if (value > 1)
                    _value = 1;
                else if (value < 0)
                    _value = 0;
                else
                    _value = value;
            }
        }

        public override string ToString()
        {
            return Fraction.FromDecimal(Value).ToString();
        }

        public decimal Price { get; set; }
    }
}