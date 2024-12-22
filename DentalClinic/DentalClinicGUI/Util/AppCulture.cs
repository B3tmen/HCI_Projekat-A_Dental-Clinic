using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DentalClinicGUI.Util
{
    internal class AppCulture
    {
        public static void ChangeCulture(string countryCode)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
                throw new ArgumentException("Country code cannot be null or empty.", nameof(countryCode));

            try
            {
                // Create a culture info object from the country code
                CultureInfo newCulture = new CultureInfo(countryCode);

                // Update the current thread's culture and UI culture
                Thread.CurrentThread.CurrentCulture = newCulture;
                //Thread.CurrentThread.CurrentUICulture = newCulture;

                //// Optionally, update the application's culture globally for WPF
                CultureInfo.DefaultThreadCurrentCulture = newCulture;
                //CultureInfo.DefaultThreadCurrentUICulture = newCulture;

                //Console.WriteLine($"Culture updated to: {newCulture.Name}");
                MessageBox.Show($"Culture updated to: {newCulture.Name}");
            }
            catch (CultureNotFoundException ex)
            {
                throw new ArgumentException($"Invalid country code: {countryCode}.", ex);
            }
        }
    }
}
