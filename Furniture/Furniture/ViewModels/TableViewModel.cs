using Caliburn.Micro;
using System.Linq;

namespace Furniture.ViewModels
{
public class TableViewModel : Screen
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
        Update();
    }

    public void RemoveItem(ItemViewModel itemViewModel)
    {
        OrdersView.Remove(itemViewModel);
    }

    public void Update()
    {
        NotifyOfPropertyChange(() => WoodTotal);
        QuotationViewModel.Update();
        NotifyOfPropertyChange(() => QuotationViewModel);
    }
}
}