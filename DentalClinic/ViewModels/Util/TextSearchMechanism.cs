using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ViewModels.Util
{
    internal class TextSearchMechanism<T> where T : class
    {
        private string _filterText;
        public ICollectionView CollectionView { get; }

        public string FilterText
        {
            get => _filterText;
            set
            {
                if (_filterText != value)
                {
                    _filterText = value;
                    CollectionView.Refresh(); // Refresh the view whenever filter text changes
                }
            }
        }

        public TextSearchMechanism(ObservableCollection<T> collection, Func<T, string> propertySelector)
        {
            CollectionView = CollectionViewSource.GetDefaultView(collection);
            CollectionView.Filter = item => Filter(item, propertySelector);
        }

        private bool Filter(object item, Func<T, string> propertySelector)
        {
            if (item is T typedItem)
            {
                // Convert both the filter text and item text to lowercase for case-insensitive filtering
                var itemText = propertySelector(typedItem)?.ToLower();
                var filterText = FilterText?.ToLower();

                return string.IsNullOrEmpty(filterText) || (itemText?.Contains(filterText) ?? false);
            }
            return false;
        }
    }
}
