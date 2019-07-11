namespace Furniture.Caption
{
    public class ComboBoxItem<TOutput>
    {
        public ComboBoxItem(string name, TOutput value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public TOutput Value { get; set; }
    }
}