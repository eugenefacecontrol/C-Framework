using System;
using System.Configuration;
using ShopByProject.Enums;

namespace ShopByProject.Utils
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

        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}