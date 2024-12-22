using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Model;
using Models.Model.Dto;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Util;

namespace ViewModels.Doctor
{
    public class MedicineViewModel : ViewModelBase
    {
        private INavigationService              _navigationService;
        private ObservableCollection<Medicine>  _medicineCollection;
        private int                             _medicineCount;
        private TextSearchMechanism<Medicine>   _searchMechanism;

        public MedicineViewModel(INavigationService navigationService) {
            _medicineCollection = new();
            _navigationService = navigationService;
            _searchMechanism = new TextSearchMechanism<Medicine>(MedicineCollection, medicine => medicine.Name);

            ShowAddMedicineCommand = new RelayCommand(execute => OnShowAddMedicine());
            RefreshCommand = new RelayCommand(execute => OnRefreshMedicine());

            LoadMedicineCollectionAsync();
        }

        
        public ICommand ShowAddMedicineCommand  { get; init; }
        public ICommand RefreshCommand          { get; init; }

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

        private void OnRefreshMedicine()
        {
            LoadMedicineCollectionAsync();
        }


        private async void LoadMedicineCollectionAsync()
        {
            IMedicineDao dao = new MedicineDaoImpl();
            List<Medicine> medicineList = await dao.GetAllAsync();

            MedicineCollection.Clear();
            if(medicineList != null)
            {
                foreach(var medicine in medicineList)
                {
                    MedicineCollection.Add(medicine);
                }
            }
            MedicineCount = MedicineCollection.Count;
        }
    }
}
