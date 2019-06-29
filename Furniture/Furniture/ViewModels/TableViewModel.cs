using System;
using System.Linq;
using Caliburn.Micro;

namespace Furniture.ViewModels
{
    public class TableViewModel : Screen
    {
        public BindableCollection<ItemViewModel> OrdersView { get; set; } = new BindableCollection<ItemViewModel>();

        public decimal Total { get; set; }

        public void AddItem()
        {
            if (OrdersView.Count == 0 || OrdersView.Last().Content != null)
                OrdersView.Add(new ItemViewModel(this));
        }

        public void UpdatePrice()
        {
            Total = OrdersView.Select(x => x.Content.Price).Sum();
        }

        public void RemoveItem(ItemViewModel itemViewModel)
        {
            OrdersView.Remove(itemViewModel);
        }
    }
}