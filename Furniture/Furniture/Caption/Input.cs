using Furniture.ViewModels;

namespace Furniture.Caption
{
    public abstract class Input : ChildViewModel
    {
        private string _value;

        public string Value
        {
            get => _value;
            set
            {
                _value = value; 
                Update();
            }
        }

        protected Input(IParent parent) : base(parent) { }
    }
}