using System.Collections.Generic;
using Newtonsoft.Json;

namespace Furniture.Work
{
    public interface ICanCalculate
    {
        string Name { get; set; }
        decimal Value { get; set; }
        [JsonIgnore] decimal Total { get; set; }

        decimal Calculate(decimal wood, List<ICanCalculate> input);
    }
}