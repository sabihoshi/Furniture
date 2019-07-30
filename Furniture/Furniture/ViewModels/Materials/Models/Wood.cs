using Furniture.ViewModels.Materials.Items;

namespace Furniture.ViewModels.Materials.Models
{
    public class Wood : IMaterial
    {
        public Wood(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}