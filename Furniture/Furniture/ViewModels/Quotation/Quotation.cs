using System.Runtime.CompilerServices;
using Furniture.Relationship;
using Newtonsoft.Json;

namespace Furniture.ViewModels.Quotation
{
    public abstract class Quotation : Child
    {
        protected Quotation(string name, decimal? value = null)
        {
            Name = name;
            Value = value;
        }

        public virtual string Name { get; }

        [JsonIgnore] public decimal? Total { get; set; }

        public decimal? Value { get; }

        [JsonIgnore] protected new QuotationViewModel Parent { get; set; }

        public void AddParent(QuotationViewModel quotation)
        {
            Parent = quotation;
        }

        public abstract decimal? GetTotal();

        public override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            Parent?.OnPropertyChanged();
        }
    }
}