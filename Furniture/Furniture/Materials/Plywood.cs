using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Furniture.Materials
{
    public class Plywood
    {
        [JsonIgnore] public Thickness Max => Thicknesses.OrderByDescending(x => x.Value).First();

        [JsonIgnore] public Thickness Min => Thicknesses.OrderByDescending(x => x.Value).Last();

        public List<Thickness> Thicknesses { get; set; }
    }
}