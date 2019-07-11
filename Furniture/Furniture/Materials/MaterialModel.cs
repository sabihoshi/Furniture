using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Furniture.Properties;
using Furniture.Relationship;
using Furniture.ViewModels;

namespace Furniture.Materials
{
    public abstract class MaterialModel : Child
    {
        public MaterialModel(IParent parent) : base(parent)
        {
        }

        public List<CaptionViewModel<decimal>> Fields { get; set; }
        public abstract string Name { get; }
        public abstract decimal Total { get; set; }
    }
}