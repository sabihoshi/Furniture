using System.Collections.Generic;
using Caliburn.Micro;

namespace Furniture.ViewModels.Materials
{
    public static class MaterialModelExtensions
    {
        public static BindableCollection<MaterialMasterViewModel> ConvertModels(this List<MaterialModel> models)
        {
            var list = new BindableCollection<MaterialMasterViewModel>();
            foreach (var model in models) list.Add(new MaterialMasterViewModel(model));

            return list;
        }
    }

    public class MaterialMasterViewModel
    {
        public MaterialMasterViewModel(MaterialModel model)
        {
            Model = model;
        }

        public MaterialModel Model { get; }
        public string Name => Model.Name;
        public decimal Total => Model.Total;
        public MaterialModel.Material Type => Model.Type;
    }
}