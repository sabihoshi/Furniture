using System;
using System.IO;
using System.Windows;
using Furniture.Quotation;
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
            Config.Work.Add(new Percentage{ Name = "Test", Value = 0.5m});
            Console.WriteLine(JsonConvert.SerializeObject(Config.Work, Formatting.Indented));
        }

        public static Config.Config Config { get; private set; }
    }
}