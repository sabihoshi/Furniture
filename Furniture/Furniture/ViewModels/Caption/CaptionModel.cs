using System.Runtime.CompilerServices;
using Furniture.Relationship;

namespace Furniture.ViewModels.Caption
{
    public class CaptionModel<T> : Child, IHasValue, IParent where T : struct
    {
        public enum CaptionType
        {
            ComboBox, TextBox
        }

        public CaptionModel(IParent parent = null, [CallerMemberName] string caption = null,
                                InputBox<T> input = null)
        {
            Parent = parent;
            Caption = caption;
            Input = input;
        }

        public string Caption { get; set; }
        public bool HasValue => Input.HasValue;
        public InputBox<T> Input { get; set; }

        public T? Value => Input.Value;
    }
}