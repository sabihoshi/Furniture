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
        private const string ConfigLocation = @"Config/config.json";
        public App()
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                NullValueHandling = NullValueHandling.Include
            };
            Config = JsonConvert.DeserializeObject<Config.Config>(File.ReadAllText(ConfigLocation), settings);
        }

        public static void RewriteConfig()
        {
            File.WriteAllText(ConfigLocation, JsonConvert.SerializeObject(Config));
        }

        public static Config.Config Config { get; private set; }
    }
}