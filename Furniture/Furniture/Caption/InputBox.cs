using Furniture.Relationship;

namespace Furniture.Caption
{
    public abstract class InputBox<T> : Child, IHasValue where T : struct
    {
        private readonly TryParse _tryParse;

        public InputBox(IParent parent, string caption, TryParse tryParse) : base(parent)
        {
            _tryParse = tryParse;
            Caption = caption;
        }

        public string Caption { get; }

        public bool HasValue => !(Value is null);

        public string Text { get; set; } = default(T).ToString();

        public virtual T? Value => _tryParse(Text, out var result) ? result : (T?) null;

        public delegate bool TryParse(string input, out T output);
    }
}