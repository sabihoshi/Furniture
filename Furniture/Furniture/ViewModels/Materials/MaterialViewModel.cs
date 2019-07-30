using System.Collections.Generic;
using Caliburn.Micro;
using Furniture.ViewModels.Materials.Items;

namespace Furniture.ViewModels.Materials
{
    public static class MaterialModelExtensions
    {
        public static BindableCollection<MaterialViewModel> ConvertToModels(this IEnumerable<MaterialBase> models)
        {
            var list = new BindableCollection<MaterialViewModel>();
            foreach (var model in models)
                list.Add(model.ConvertToModel());

            return list;
        }

        public static MaterialViewModel ConvertToModel(this MaterialBase model)
        {
            return new MaterialViewModel(model);
        }
    }

    public class MaterialViewModel
    {
        public MaterialViewModel(MaterialBase model)
        {
            Model = model;
        }

        public MaterialBase Model { get; }

        public string Name => Model.Name;

        public decimal Total => Model.Total;

        public MaterialBase.Material Type => Model.Type;
    }
}