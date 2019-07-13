using System.Runtime.CompilerServices;

namespace Furniture.Relationship
{
    public interface IParent
    {
        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}