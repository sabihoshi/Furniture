using System.ComponentModel;
using System.Runtime.CompilerServices;
using Furniture.Properties;

namespace Furniture.ViewModels
{
    public abstract class MaterialViewModel : ChildViewModel, INotifyPropertyChanged
    {
        public MaterialViewModel(IParentViewModel parentViewModel) : base(parentViewModel) { }

        public abstract string Name { get; }
        public abstract decimal Total { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}