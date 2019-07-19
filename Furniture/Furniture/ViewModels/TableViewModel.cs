using System.Linq;
using Caliburn.Micro;
using Furniture.Properties;
using Furniture.Relationship;
using Furniture.ViewModels.Materials;
using Furniture.ViewModels.Quotation;

namespace Furniture.ViewModels
{
    public class TableViewModel : Parent
    {
        public TableViewModel()
        {
            QuotationViewModel = new QuotationViewModel(this);
            AddItem();
        }

        public BindableCollection<ItemViewModel> OrdersView { get; set; } = new BindableCollection<ItemViewModel>();
        public QuotationViewModel QuotationViewModel { get; set; }

        [UsedImplicitly]
        public void AddItem()
        {
            if (OrdersView.Count != 0 && OrdersView.Last().Content == null)
                return;
            OrdersView.Add(new ItemViewModel(this));
            OnPropertyChanged();
        }

        public decimal? GetTotal(MaterialBase.Material type)
        {
            var result = OrdersView.Where(x => x.Type == type).Sum(x => x.Content.Total);
            return result;
        }

        public override void OnPropertyChanged(string propertyName = null)
        {
            QuotationViewModel.OnPropertyChanged();
            base.OnPropertyChanged(propertyName);
        }

        public void RemoveItem(ItemViewModel itemViewModel)
        {
            OrdersView.Remove(itemViewModel);
        }
    }
}