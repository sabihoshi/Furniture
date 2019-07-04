using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace Furniture
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Config.Config Config = JsonConvert.DeserializeObject<Config.Config>(File.ReadAllText("Config/config.json"));
    }
}