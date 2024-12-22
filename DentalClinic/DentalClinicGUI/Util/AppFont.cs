using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using ViewModels.Util;

namespace DentalClinicGUI.Util
{
    class AppFont
    {
        public static void ChangeFont(string name)
        {
            // Update the global FontFamily resource
            //MessageBoxShower.ShowErrorBox("", $"{name}");
            
            Application.Current.Resources["AppFontFamily"] = new FontFamily(name);
        }
    }
}
