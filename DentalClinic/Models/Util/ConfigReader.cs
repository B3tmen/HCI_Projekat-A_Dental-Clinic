using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Configuration;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace Models.Util
{
    public class ConfigReader
    {
        // Thread-safe implementation of Singleton pattern using Lazy<T>

        private static readonly Lazy<ConfigReader> _instance = new Lazy<ConfigReader>(() => new ConfigReader());
        public static ConfigReader Instance => _instance.Value;

        public string ConnectionString { get; init; }

        private ConfigReader()
        {
            string filePath = GetFileName();    //"../../../Config/Database.config"
            var config = LoadCustomConfig(filePath);

            ConnectionString = config.AppSettings.Settings["ConnectionString"]?.Value;
        }

        private Configuration LoadCustomConfig(string configFileName)
        {
            var map = new ExeConfigurationFileMap { ExeConfigFilename = configFileName };
            return ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
        }

        /// <summary>
        /// Gets the relative file path of the config file, because we can use this class library from
        /// multiple projects, hence having different file paths (e.g.Project/bin/debug/net8.0/...exe)
        /// </summary>
        /// <returns></returns>
        private string GetFileName()
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + @"\..\..\..\..\Models\Config\Database.config";

            return filePath;
        }
    }
}
