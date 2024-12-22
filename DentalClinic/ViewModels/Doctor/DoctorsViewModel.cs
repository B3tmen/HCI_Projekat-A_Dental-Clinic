using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using System.Collections.ObjectModel;
using ViewModels.Util;

namespace ViewModels.Doctor
{
    public class DoctorsViewModel : ViewModelBase
    {
        
        private int                                         _doctorCount;
        private ObservableCollection<Models.Model.Doctor>   _doctorsCollection;
        private TextSearchMechanism<Models.Model.Doctor>    _searchMechanism;

        public DoctorsViewModel() {
            _doctorsCollection = new();
            _searchMechanism = new TextSearchMechanism<Models.Model.Doctor>(DoctorsCollection, doctor => doctor.LastName);

            SetupDoctorCollectionAsync();
        }

        public int DoctorsCount
        {
            get => _doctorCount;
            set
            {
                _doctorCount = value;
                OnPropertyChanged(nameof(DoctorsCount));
            }
        }

        public ObservableCollection<Models.Model.Doctor> DoctorsCollection { 
            get => _doctorsCollection; 
            set {
                _doctorsCollection = value;
                OnPropertyChanged(nameof(DoctorsCollection));
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


        private async void SetupDoctorCollectionAsync()
        {
            //IDoctorDao dao = new DoctorDaoImpl();
            //List<Models.Model.Doctor> doctorsList = dao.GetAllAsync();

            //foreach (var item in doctorsList)
            //{
            //    DoctorsCollection.Add(item);
            //}
            //DoctorsCount = DoctorsCollection.Count;

            IDoctorDao dao = new DoctorDaoImpl();
            List<Models.Model.Doctor> doctors = await dao.GetAllAsync();

            if (doctors != null)
            {
                foreach (var item in doctors)
                {
                    DoctorsCollection.Add(item);
                }
                DoctorsCount = DoctorsCollection.Count;
            }
        }
    }
}
