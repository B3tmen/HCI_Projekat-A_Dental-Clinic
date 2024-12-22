using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Util;

namespace ViewModels.Administrator
{
    public class StorageViewModel : ViewModelBase
    {
        private INavigationService              _navigationService;
        private ObservableCollection<Medicine>  _medicineCollection;
        private TextSearchMechanism<Medicine>   _searchMechanism;
        private int                             _medicineCount;

        public StorageViewModel(INavigationService navigationService)
        {
            _medicineCollection = new();
            _navigationService = navigationService;
            _searchMechanism = new TextSearchMechanism<Medicine>(MedicineCollection, medicine => medicine.Name);

            ShowAddMedicineCommand = new RelayCommand(execute => OnShowAddMedicine());
            ShowUpdateMedicineCommand = new RelayCommand(OnShowUpdateMedicine);
            RefreshCommand = new RelayCommand(execute => OnRefreshStorage());

            LoadMedicineCollectionAsync();
        }

        public ICommand ShowAddMedicineCommand      { get; init; }
        public ICommand ShowUpdateMedicineCommand   { get; init; }
        public ICommand RefreshCommand              { get; init; }

        public ObservableCollection<Medicine> MedicineCollection
        {
            get => _medicineCollection;
            set
            {
                _medicineCollection = value;
                OnPropertyChanged(nameof(MedicineCollection));
            }
        }

        public int MedicineCount
        {
            get => _medicineCount;
            set
            {
                _medicineCount = value;
                OnPropertyChanged(nameof(MedicineCount));
            }
        }

        public string SearchText
        {
            get => _searchMechanism.FilterText;
            set
            {
                if (_searchMechanism.FilterText != value)
                {
                    _searchMechanism.FilterText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }


        private void OnShowAddMedicine()
        {
            _navigationService.NavigateToWindow("AddMedicineWindow");
        }

        private void OnShowUpdateMedicine(object parameter)
        {
            _navigationService.NavigateToWindow("UpdateMedicineWindow", parameter);
        }

        private void OnRefreshStorage()
        {
            LoadMedicineCollectionAsync();
        }

        private async void LoadMedicineCollectionAsync()
        {
            IMedicineDao dao = new MedicineDaoImpl();
            List<Medicine> medicineList = await dao.GetAllAsync();

            MedicineCollection.Clear();
            if (medicineList != null)
            {
                foreach (var medicine in medicineList)
                {
                    MedicineCollection.Add(medicine);
                }
            }
            MedicineCount = MedicineCollection.Count;
        }
    }
}
