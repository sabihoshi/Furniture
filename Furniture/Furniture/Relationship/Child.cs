using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Furniture.Relationship
{
    public abstract class Child : INotifyPropertyChanged
    {
        protected Child(IParent parent = null)
        {
            Parent = parent;
        }

        public IParent Parent { get; private set; }

        public Child AddViewModel(IParent parent)
        {
            Parent = parent;
            return this;
        }

        public virtual void Update()
        {
            Parent?.Update();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}