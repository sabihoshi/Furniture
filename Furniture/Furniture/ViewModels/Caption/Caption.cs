using System.Runtime.CompilerServices;
using Furniture.Relationship;

namespace Furniture.ViewModels.Caption
{
    public class Caption<T> : Child, IHasValue, IParent where T : struct
    {
        public Caption(IParent parent = null, [CallerMemberName] string caption = null,
            InputBox<T> input = null)
        {
            Parent = parent;
            Name = caption;
            Input = input;
        }

        public string Name { get; set; }

        public bool HasValue => Input.HasValue;

        public InputBox<T> Input { get; set; }

        public T? Value => Input.Value;
    }
}