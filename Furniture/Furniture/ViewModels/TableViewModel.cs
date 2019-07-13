using System.Linq;
using Caliburn.Micro;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public class TableViewModel : Parent
    {
        public TableViewModel()
        {
            QuotationViewModel = new QuotationViewModel(this);
        }

        public BindableCollection<ItemViewModel> OrdersView { get; set; } = new BindableCollection<ItemViewModel>();
        public QuotationViewModel QuotationViewModel { get; set; }
        public decimal WoodTotal => OrdersView.Select(x => x.Content.Total).Sum();
        public void AddItem()
        {
            if (OrdersView.Count != 0 && OrdersView.Last().Content == null)
                return;
            OrdersView.Add(new ItemViewModel(this));
            OnPropertyChanged();
        }

        public void RemoveItem(ItemViewModel itemViewModel)
        {
            OrdersView.Remove(itemViewModel);
        }

        public override void OnPropertyChanged(string propertyName = null)
        {
            QuotationViewModel.OnPropertyChanged();
            base.OnPropertyChanged(propertyName);
        }
    }
}