using Furniture.ViewModels.Materials;

namespace Furniture.ViewModels.Quotation
{
    public class Source : Quotation
    {
        public Source(string name, decimal? value = null) : base(name, value) { }
        public MaterialModel.Material Type { get; set; }

        public override decimal? GetTotal()
        {
            return Parent?.GetTotal(Type);
        }
    }
}