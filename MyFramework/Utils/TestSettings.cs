using System;
using System.Configuration;
using MyFramework.Enums;

namespace MyFramework.Utils
{
    public static class TestSettings
    {
        public static string BaseURL => GetSetting("baseURL");

        public static BrowserEnum BrowserName
        {
            get
            {
                Enum.TryParse(GetSetting("browserName"), true, out BrowserEnum browser);
                return browser;
            }
        }

        public static double ExplicitTimeout => double.Parse(GetSetting("explicitTimeout"));
        public static double ImplicitTimeout => double.Parse(GetSetting("implicitTimeout"));
        public static string SauceUsername => GetSetting("sauceUsername");
        public static string SauceAccessKey => GetSetting("sauceAccessKey");

        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void GetAllSettings()
        {
            var appSettings = ConfigurationManager.AppSettings;
            foreach (var key in appSettings.AllKeys)
            {
                Console.WriteLine($"{appSettings[key]}: {key}");
            }
        }
    }
}