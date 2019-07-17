using System.ComponentModel;
using System.Runtime.CompilerServices;
using Caliburn.Micro;

namespace Furniture.Relationship
{
    public abstract class Parent : Screen, IParent
    {
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override event PropertyChangedEventHandler PropertyChanged;
    }
}