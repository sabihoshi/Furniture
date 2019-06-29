using System.Collections.Generic;

namespace Furniture.Models
{
    public class Config
    {
        public Config(List<Material> materials)
        {
            Materials = materials;
        }
        public List<Material> Materials { get; set; }

        public class Material
        {
            public string Name { get; set; }
            public int Type { get; set; }
            public List<Thickness> Thicknesses { get; set; }
            
        }

    }
}
