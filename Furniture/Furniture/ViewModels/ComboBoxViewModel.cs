using System.Collections.Generic;
using Furniture.Caption;
using Furniture.Relationship;

namespace Furniture.ViewModels
{
    public class ComboBoxViewModel<TOutput> : Input<TOutput> 
    {
        public ComboBoxViewModel(IParent parent, List<ComboBoxItem<TOutput>> values) : base(parent)
        {
            Values = values;
        }
        public List<ComboBoxItem<TOutput>> Values { get; set; }
        public ComboBoxViewModel(IParent parent) : base(parent) { }
        public override InputType Type { get; } = InputType.ComboBox;
    }
}