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
        public App()
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            };
            Config = JsonConvert.DeserializeObject<Config.Config>(File.ReadAllText("Config/config.json"), settings);
        }

        public static Config.Config Config { get; private set; }
    }
}