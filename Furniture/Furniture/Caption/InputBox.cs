using System;
using Furniture.Relationship;

namespace Furniture.Caption
{
    public abstract class InputBox<T> : Child where T : IConvertible
    {
        private string _output;

        public InputBox(IParent parent, string caption) : base(parent)
        {
            Caption = caption;
        }

        public string Output
        {
            get => _output;
            set
            {
                _output = value;
                if (Output.TryParse<T>(out var result))
                    TValue = result;
            }
        }

        public string Caption { get; }

        public virtual T TValue { get; set; }
    }
}