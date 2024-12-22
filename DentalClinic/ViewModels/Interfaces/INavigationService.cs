// Vanja
using System.Windows.Controls;

namespace ViewModels.Interfaces
{
    public interface INavigationService
    {
        void NavigateToWindow(string windowName, object parameter = null);

        Page NavigateToPage(string pageName, object parameter = null);
    }
}
