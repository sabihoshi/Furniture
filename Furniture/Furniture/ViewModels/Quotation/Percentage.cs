using System.Dynamic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;

namespace Furniture.ViewModels.Quotation
{
    public class Percentage : Quotation
    {
        public Percentage(string name, decimal value) : base(name, value) { }

        public override decimal? GetTotal()
        {
            return Parent?.Quotations.TakeWhile(x => x != this).Sum(x => x.Total) * Value;
        }
    }
}