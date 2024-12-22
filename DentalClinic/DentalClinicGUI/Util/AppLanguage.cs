using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModels.Services;

namespace DentalClinicGUI.Util
{
    internal class AppLanguage
    {
        public static void ChangeLanguage(Uri languageURI)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary()
            {
                Source = languageURI
            };

            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }
}
