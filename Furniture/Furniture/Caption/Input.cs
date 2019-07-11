using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Furniture.Relationship;
using Furniture.ViewModels;
using PropertyChanged;

namespace Furniture.Caption
{
    public abstract class Input<TOutput> : Child
    {
        public Input(IParent parent) : base(parent)
        {
            
        }
        public enum InputType
        {
            TextBox,
            ComboBox
        }
        public abstract InputType Type { get; }

        private string _output;
        public virtual TOutput Value { get; set; }

        public override void Update()
        {
            if (!Output.Convert<TOutput>(out var result)) return;
            Value = result;
            base.Update();
        }

        public string Output
        {
            get => _output;
            set
            {
                _output = value; 
                Update();
            }
        }
    }
}