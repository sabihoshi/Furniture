using Furniture.Relationship;
using Newtonsoft.Json;

namespace Furniture.ViewModels.Caption
{
    public class ComboBoxItem<TOutput> : Child
    {
        [JsonConstructor]
        public ComboBoxItem(string name, TOutput value)
        {
            Name = name;
            Value = value;
        }

        public ComboBoxItem(TOutput value) : this(value.ToString(), value) { }

        public string Name { get; set; }
        public TOutput Value { get; set; }
    }
}