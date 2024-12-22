using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DentalClinicGUI.Util
{
    internal class AppTheme
    {



        public static void ChangeTheme(Uri themeURI)
        {
            ResourceDictionary themeDictionary = new ResourceDictionary() { 
                Source = themeURI,
            } ;

            App.Current.Resources.Clear();      // if theme already defined, clear it
            
            App.Current.Resources.MergedDictionaries.Add(themeDictionary);

            
        }
    }
}
