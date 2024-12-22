using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModels.Services
{
    public static class LanguageService
    {
        public static ResourceManager s_rm = new ResourceManager("ViewModels.Resources.LanguageStrings.Strings", typeof(LanguageService).Assembly);

        public static CultureInfo CurrentCulture { get; set; }

        public static void SetLanguage(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);
            CurrentCulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
        }

        public static string GetString(string key)
        {
            return s_rm.GetString(key, CurrentCulture);
        }
    }
}
