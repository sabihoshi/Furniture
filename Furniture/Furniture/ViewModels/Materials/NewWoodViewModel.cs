using System.Windows;
using Caliburn.Micro;
using Furniture.ViewModels.Materials.Models;

namespace Furniture.ViewModels.Materials
{
    public class NewWoodViewModel : ViewAware
    {
        public NewWoodViewModel(TableViewModel parent)
        {
            Parent = parent;
        }

        public TableViewModel Parent { get; }

        public Wood Wood { get; } = new Wood("New wood", 100);

        public void Okay()
        {
            OnViewClosed();
            Parent.OnWoodCreated(Wood);
        }

        public void OnViewClosed()
        {
            (GetView() as Window)?.Close();

            if (Parent.GetView() is Window view)
            {
                view.Opacity = 100;
                view.Effect = null;
            }
        }
    }
}