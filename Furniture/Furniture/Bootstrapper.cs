using System.Windows;
using Caliburn.Micro;
using Furniture.ViewModels;

namespace Furniture
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly IWindowManager manager = new WindowManager();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            manager.ShowWindow(new TableViewModel());
        }
    }
}