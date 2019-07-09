namespace Furniture.ViewModels
{
    public abstract class ChildViewModel
    {
        protected IParentViewModel ParentViewModel;

        protected ChildViewModel(IParentViewModel parentViewModel)
        {
            ParentViewModel = parentViewModel;
        }

        public ChildViewModel AddViewModel(IParentViewModel parent)
        {
            ParentViewModel = parent;
            return this;
        }

        protected virtual void Update()
        {
            ParentViewModel?.Update();
        }
    }
}