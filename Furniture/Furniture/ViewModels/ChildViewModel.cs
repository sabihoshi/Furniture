namespace Furniture.ViewModels
{
    public abstract class ChildViewModel
    {
        protected readonly ItemViewModel _sourceViewModel;

        public ChildViewModel(ItemViewModel sourceViewModel)
        {
            _sourceViewModel = sourceViewModel;
        }

        public abstract string Name { get; }

        public abstract decimal Total { get; set; }
        public abstract void Update();
    }
}