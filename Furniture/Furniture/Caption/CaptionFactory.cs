using Furniture.ViewModels;

namespace Furniture.Caption
{
    public static class CaptionFactory
    {
        public static CaptionViewModel CreateTextBox(this IParent parent, string caption)
        {
            return CreateCaption(parent, caption, new TextBoxViewModel(parent));
        }

        public static CaptionViewModel CreateComboBox(this IParent parent, string caption)
        {
            return CreateCaption(parent, caption, new ComboBoxViewModel(parent));
        }

        public static CaptionViewModel CreateCaption(IParent parent, string caption, Input input)
        {
            return new CaptionViewModel(parent, caption, input);
        }
    }
}
