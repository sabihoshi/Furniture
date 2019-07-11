namespace Furniture.ViewModels
{
    public abstract class ChildViewModel
    {
        protected IParent Parent;

        protected ChildViewModel(IParent parent)
        {
            Parent = parent;
        }

        public ChildViewModel AddViewModel(IParent parent)
        {
            Parent = parent;
            return this;
        }

        public virtual void Update()
        {
            Parent?.Update();
        }
    }
}