using Furniture.ViewModels.Materials.Items;

namespace Furniture.ViewModels.Materials.Models
{
    public class Piece : IMaterial
    {
        public MaterialBase.Material Type { get; set; }

        public string Name { get; set; }

        public decimal Value { get; set; }
    }
}