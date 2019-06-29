using System.Collections.Generic;
using Furniture.Models;
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace Furniture
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Config Config = new Config(JsonConvert.DeserializeObject<List<Config.Material>>(File.ReadAllText("Config/config.json")));
    }
}