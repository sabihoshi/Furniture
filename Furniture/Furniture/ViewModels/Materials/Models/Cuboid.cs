using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furniture.ViewModels.Materials.Items;

namespace Furniture.ViewModels.Materials.Models
{
    public static class CuboidExtensions
    {
        public static Cuboid GetCuboid(this MaterialBase material) =>
            App.Config.Cuboids.FirstOrDefault(c => c.Type == material.Type);
    }
    public class Cuboid
    {
        public List<int> Widths { get; set; }

        public List<int> Lengths { get; set; }

        public MaterialBase.Material  Type { get; set; }
    }
}