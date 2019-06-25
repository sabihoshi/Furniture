using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Furniture.ViewModels
{
    public class TableViewModel : Screen
    {
        public BindableCollection<PlywoodViewModel> OrdersView { get; set; }= new BindableCollection<PlywoodViewModel>();
        public TableViewModel()
        {
            OrdersView.Add(new PlywoodViewModel());
        }
    }
}
