using Furniture.Caption;

namespace Furniture.ViewModels
{
    public class CaptionViewModel : ChildViewModel, IParent
    {
        public CaptionViewModel(IParent parent, string caption, Input input) : base(parent)
        {
            Caption = caption;
            Input = input;
        }

        public string Caption { get; set; }
        public Input Input { get; set; }
        public override void Update()
        {
            Parent.Update();
        }
    }
}