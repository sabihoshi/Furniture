using System.Collections.Generic;
using Furniture.Caption;

namespace Furniture.ViewModels
{
    public class ComboBoxViewModel : Input
    {
        public ComboBoxViewModel(IParent parent, List<string> values) : base(parent)
        {
            Values = values;
        }
        public List<string> Values { get; set; }
        public ComboBoxViewModel(IParent parent) : base(parent) { }
    }
}