using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Furniture.ViewModels.Materials
{
    public static class MaterialModelExtensions
    {
        public static BindableCollection<MaterialMasterViewModel> ConvertModels(this List<MaterialModel> models)
        {
            var list = new BindableCollection<MaterialMasterViewModel>();
            foreach (var model in models)
            {
                list.Add(new MaterialMasterViewModel(model));
            }

            return list;
        }
    }
    public class MaterialMasterViewModel
    {
        public decimal Total => Model.Total;
        public MaterialModel.Material Type => Model.Type;
        public string Name => Model.Name;
        public MaterialModel Model { get; }
        public MaterialMasterViewModel(MaterialModel model)
        {
            Model = model;
        }
    }
}
