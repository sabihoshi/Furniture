using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Caliburn.Micro;
using Furniture.Materials;

namespace Furniture.ViewModels
{
    public class TableViewModel : Screen
    {
        public TableViewModel()
        {
            Work.Woods = new List<Wood>();
        }

        public DataGrid DataGrid { get; set; } = new DataGrid();
        public BindableCollection<ItemViewModel> OrdersView { get; set; } = new BindableCollection<ItemViewModel>();

        public decimal Total { get; set; }

        public Work.Work Work { get; set; } = new Work.Work();

        public void AddItem()
        {
            if (OrdersView.Count != 0 && OrdersView.Last().Content == null)
                return;
            OrdersView.Add(new ItemViewModel(this));
            UpdatePrice();
        }

        public void RemoveItem(ItemViewModel itemViewModel)
        {
            OrdersView.Remove(itemViewModel);
        }

        public void UpdatePrice()
        {
            Total = OrdersView.Select(x => x.Content.Total).Sum();
        }
    }
}