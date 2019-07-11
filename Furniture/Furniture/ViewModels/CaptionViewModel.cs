using System.Runtime.CompilerServices;
using Furniture.Caption;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public class CaptionViewModel<TOutput> : Child, IParent
    {
        public enum CaptionType
        {
            ComboBox,
            TextBox
        }
        public CaptionViewModel(IParent parent, string caption, Input<TOutput> input) : base(parent) 
        {
            Caption = caption;
            Input = input;
        }

        public CaptionViewModel([CallerMemberName] string caption = null)
        {
            Caption = caption;
        }

        public TOutput Value => Input.Value;
        public string Caption { get; set; }
        public Input<TOutput> Input { get; set; }
    }
}