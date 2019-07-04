namespace Furniture.ViewModels
{
    public abstract class ChildModel
    {
        protected readonly ItemViewModel _sourceViewModel;

        public ChildModel(ItemViewModel sourceViewModel)
        {
            _sourceViewModel = sourceViewModel;
        }

        public abstract string Name { get; }

        public abstract decimal Total { get; set; }
        public abstract void UpdatePrice();
    }
}