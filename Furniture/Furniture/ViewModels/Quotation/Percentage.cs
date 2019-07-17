using System.Dynamic;
using System.Linq;
using System.Windows;
using Caliburn.Micro;

namespace Furniture.ViewModels.Quotation
{
    public class Percentage : Quotation
    {
        private readonly IWindowManager _manager = new WindowManager();

        public Percentage(string name, decimal value) : base(name, value) { }

        public void EditValues()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.Height = 600;
            settings.Width = 300;
            settings.SizeToContent = SizeToContent.Manual;
            settings.ResizeMode = ResizeMode.NoResize;
            // settings.WindowStyle = WindowStyle.None;

            _manager.ShowDialog(new QuotationEditViewModel(), settings: settings);
        }

        public override decimal? GetTotal()
        {
            return Parent?.Quotations.TakeWhile(x => x != this).Sum(x => x.Total) * Value;
        }
    }
}