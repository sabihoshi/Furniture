using Furniture.ViewModels.Materials.Items;

namespace Furniture.ViewModels.Quotation
{
    public class Source : Quotation
    {
        public Source(string name, decimal? value = null) : base(name, value) { }

        public MaterialBase.Material Type { get; set; }

        public override decimal? GetTotal()
        {
            return Parent?.GetTotal(Type);
        }
    }
}