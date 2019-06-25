using System.Collections.Generic;
using Fractions;

namespace Furniture.Models
{
    public class Thickness
    {
        private decimal _percentage;

        public static List<Thickness> CreateList(Dictionary<decimal, decimal> dict)
        {
            var list = new List<Thickness>();
            foreach (var item in dict)
            {
                list.Add(new Thickness(item.Key, item.Value));
            }

            return list;
        }
        public Thickness(decimal percentage = 0, decimal price = 0)
        {
            Percentage = percentage;
            Price = price;
        }

        public decimal Percentage
        {
            get => _percentage;
            set
            {
                if (value > 1)
                    _percentage = 1;
                else if (value < 0)
                    _percentage = 0;
                else
                    _percentage = value;
            }
        }

        public override string ToString()
        {
            return Fraction.FromDecimal(Percentage).ToString();
        }

        public decimal Price { get; set; }
    }
}