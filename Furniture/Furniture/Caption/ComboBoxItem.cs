using System.ComponentModel;
using System.Runtime.CompilerServices;
using Furniture.Relationship;
using Newtonsoft.Json;

namespace Furniture.Caption
{
    public class ComboBoxItem<TOutput> : Child
    {
        [JsonConstructor]
        public ComboBoxItem(string name, TOutput value)
        {
            Name = name;
            Value = value;
        }

        public ComboBoxItem(TOutput value)
        {
            Value = value;
            Name = value.ToString();
        }

        public string Name { get; set; }
        public TOutput Value { get; set; }
    }
}