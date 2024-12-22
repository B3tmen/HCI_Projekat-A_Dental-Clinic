using System.Configuration;
using System.Data;
using System.Globalization;
using System.Windows;

namespace DentalClinicGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //InitializeCultures();
        }

        private void InitializeCultures()
        {
            // Set the culture to German (Germany)
            var germanCulture = new CultureInfo("de-DE");

            // Apply to the current thread (UI thread)
            Thread.CurrentThread.CurrentCulture = germanCulture;
            Thread.CurrentThread.CurrentUICulture = germanCulture;
        }
    }

}
