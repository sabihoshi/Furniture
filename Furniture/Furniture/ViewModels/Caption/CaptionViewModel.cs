using System.Runtime.CompilerServices;
using Furniture.Relationship;

namespace Furniture.ViewModels.Caption
{
    public class CaptionViewModel<T> : Child, IHasValue, IParent where T : struct
    {
        public enum CaptionType
        {
            ComboBox,
            TextBox
        }
        public CaptionViewModel(IParent parent = null, [CallerMemberName] string caption = null, InputBox<T> input = null)
        {
            Parent = parent;
            Caption = caption;
            Input = input;
        }

        public T? Value => Input.Value;
        public bool HasValue => Input.HasValue;

        public string Caption { get; set; }
        public InputBox<T> Input { get; set; }
    }
}