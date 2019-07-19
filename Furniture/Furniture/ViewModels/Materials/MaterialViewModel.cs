using System.Collections.Generic;
using Caliburn.Micro;

namespace Furniture.ViewModels.Materials
{
    public static class MaterialModelExtensions
    {
        public static BindableCollection<MaterialViewModel> ConvertModels(this List<MaterialBase> models)
        {
            var list = new BindableCollection<MaterialViewModel>();
            foreach (var model in models) list.Add(new MaterialViewModel(model));

            return list;
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