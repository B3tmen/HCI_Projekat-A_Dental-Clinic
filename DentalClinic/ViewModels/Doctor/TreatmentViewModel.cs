using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Services;
using ViewModels.Util;

namespace ViewModels.Doctor
{
    using ChipModel = Models.Model.ChipModel;

    public class TreatmentViewModel : ViewModelBase, IParameterReceiver
    {
        private const decimal _priceBase = 10;

        private string                          _treatmentDescription;
        private string                          _toothName;
        private string                          _patientName;
        private bool                            _isSelected;

        private Treatment                       _treatment;
        private Brush                           _selectedEllipseColor;
        private Patient                         _patient;
        private ObservableCollection<ChipModel> _teethCollection;   // Chip is a MaterialDesign UI element, hence ChipModel
        private ObservableCollection<Medicine>  _medicineCollection;
        private Dictionary<string, Brush>       _teethMap;

        public TreatmentViewModel() {
            _treatmentDescription = string.Empty;
            _toothName = string.Empty;
            
            _treatment = new();
            _teethMap = new();
            _teethCollection = new();
            _medicineCollection = new();

            FinishTreatmentCommand = new RelayCommand(execute => OnFinishTreatmentAsync());
            EllipseClickCommand = new RelayCommand(OnEllipseClick);
            DeleteChipCommand = new RelayCommand(OnDeleteChip);

            SetupMedicineCollectionAsync(); 
        }


        public ICommand FinishTreatmentCommand  { get; }
        public ICommand EllipseClickCommand     { get; }
        public ICommand DeleteChipCommand       { get; }

        public ObservableCollection<ChipModel> TeethCollection
        {
            get => _teethCollection;
            set
            {
                _teethCollection = value;
                OnPropertyChanged(nameof(TeethCollection));
            }
        }

        public ObservableCollection<Medicine> MedicineCollection
        {
            get => _medicineCollection;
            set
            {
                _medicineCollection = value;
                OnPropertyChanged(nameof(MedicineCollection));
            }
        }

        public string ToothName
        {
            get => _toothName;
            set
            {
                _toothName = value;
                OnPropertyChanged(nameof(ToothName));   
            }
        }

        public string TreatmentDescription
        {
            get => _treatmentDescription;
            set
            {
                _treatmentDescription = value;
                OnPropertyChanged(nameof(TreatmentDescription));    
            }
        }

        public Treatment Treatment
        {
            get => _treatment;
            set
            {
                _treatment = value;
                OnPropertyChanged(nameof(Treatment));
            }
        }

        public Medicine SelectedMedicine { get; set; } = new Medicine();

        public Patient Patient 
        {
            get => _patient;

            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient)); 
            }
        }

        public string PatientName
        {
            get => _patientName;
            set
            {
                _patientName = value;
                OnPropertyChanged(nameof(PatientName));
            }
        }


        public Brush EllipseColorTR1 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTR2 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTR3 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTR4 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTR5 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTR6 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTR7 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTR8 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTL1 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTL2 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTL3 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTL4 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTL5 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTL6 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTL7 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorTL8 { get; set; } = new SolidColorBrush(Colors.Transparent);

        public Brush EllipseColorBR1 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBR2 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBR3 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBR4 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBR5 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBR6 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBR7 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBR8 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBL1 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBL2 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBL3 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBL4 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBL5 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBL6 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBL7 { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Brush EllipseColorBL8 { get; set; } = new SolidColorBrush(Colors.Transparent);


        private void ChangeEllipseProperties()
        {
            OnPropertyChanged(nameof(EllipseColorTR1));
            OnPropertyChanged(nameof(EllipseColorTR2));
            OnPropertyChanged(nameof(EllipseColorTR3));
            OnPropertyChanged(nameof(EllipseColorTR4));
            OnPropertyChanged(nameof(EllipseColorTR5));
            OnPropertyChanged(nameof(EllipseColorTR6));
            OnPropertyChanged(nameof(EllipseColorTR7));
            OnPropertyChanged(nameof(EllipseColorTR8));
            OnPropertyChanged(nameof(EllipseColorTL1));
            OnPropertyChanged(nameof(EllipseColorTL2));
            OnPropertyChanged(nameof(EllipseColorTL3));
            OnPropertyChanged(nameof(EllipseColorTL4));
            OnPropertyChanged(nameof(EllipseColorTL5));
            OnPropertyChanged(nameof(EllipseColorTL6));
            OnPropertyChanged(nameof(EllipseColorTL7));
            OnPropertyChanged(nameof(EllipseColorTL8));

            OnPropertyChanged(nameof(EllipseColorBR1));
            OnPropertyChanged(nameof(EllipseColorBR2));
            OnPropertyChanged(nameof(EllipseColorBR3));
            OnPropertyChanged(nameof(EllipseColorBR4));
            OnPropertyChanged(nameof(EllipseColorBR5));
            OnPropertyChanged(nameof(EllipseColorBR6));
            OnPropertyChanged(nameof(EllipseColorBR7));
            OnPropertyChanged(nameof(EllipseColorBR8));
            OnPropertyChanged(nameof(EllipseColorBL1));
            OnPropertyChanged(nameof(EllipseColorBL2));
            OnPropertyChanged(nameof(EllipseColorBL3));
            OnPropertyChanged(nameof(EllipseColorBL4));
            OnPropertyChanged(nameof(EllipseColorBL5));
            OnPropertyChanged(nameof(EllipseColorBL6));
            OnPropertyChanged(nameof(EllipseColorBL7));
            OnPropertyChanged(nameof(EllipseColorBL8));
        }


        private async void OnFinishTreatmentAsync()
        {
            bool checkEnteredFields = true;

            if (string.IsNullOrEmpty(Treatment.Description))
            {
                checkEnteredFields = false;
                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_DescriptionNotEntered"), LanguageService.GetString("TryAgain"));
            }
            if (string.IsNullOrEmpty(Treatment.Name)) 
            {
                checkEnteredFields = false;
                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_NameNotEntered"), LanguageService.GetString("TryAgain"));
            }
            if (SelectedMedicine == null)
            {
                checkEnteredFields = false;
                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_MedicineNotSelected"), LanguageService.GetString("TryAgain"));
            }
            if (TeethCollection.Count == 0)
            {
                checkEnteredFields = false;
                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_NoToothSelected"), LanguageService.GetString("TryAgain"));
            }

            if (checkEnteredFields)
            {
                string teethJson = JsonService<ObservableCollection<ChipModel>>.ToJson(TeethCollection);
                decimal price = _priceBase * TeethCollection.Count;
                
                Treatment treatment = new Treatment(0, Treatment.Name, Treatment.Description, price, SelectedMedicine.MedicineId, teethJson);

                ITreatmentDao treatmentDao = new TreatmentDaoImpl();
                IReceiptDao receiptDao = new ReceiptDaoImpl();
                IReceiptItemDao receiptItemDao = new ReceiptItemDaoImpl();

                bool inserted = await treatmentDao.InsertAsync(treatment);

                if (inserted)
                {
                    Receipt receipt = new Receipt(0, Patient.PatientId, 0, DateTime.Now);
                    bool insertedReceipt = await receiptDao.InsertAsync(receipt);
                    if (insertedReceipt)
                    {
                        ReceiptItem receiptItem = new ReceiptItem(receipt.ReceiptId, treatment.TreatmentId, treatment.Price, TeethCollection.Count, price * TeethCollection.Count);
                        bool insertedItem = await receiptItemDao.InsertAsync(receiptItem);
                        if (insertedItem)
                        {
                            MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_AddTreatment"), LanguageService.GetString("PressOK"));
                        }
                    }
                }
            }
        }

        private void OnEllipseClick(object parameter)
        {
            if(parameter is string toothPosition)
            {
                ChipModel chip = new ChipModel { Text = toothPosition };
                if (_teethMap.ContainsKey(toothPosition))  
                {

                    Brush ellipseColor;
                    if(_teethMap.TryGetValue(toothPosition, out ellipseColor))
                    {
                        if(((SolidColorBrush) ellipseColor).Color.Equals(Colors.Transparent))
                        {
                            SetEllipseColor(toothPosition, new SolidColorBrush(Colors.Red));
                            TeethCollection.Add(chip);
                        }
                        else
                        {
                            SetEllipseColor(toothPosition, new SolidColorBrush(Colors.Transparent));
                            TeethCollection.Remove(chip);
                        }
                    }
                }
                else
                {
                    SetEllipseColor(toothPosition, new SolidColorBrush(Colors.Red));
                    
                    TeethCollection.Add(chip);
                    ToothName = toothPosition;
                }
            }
        }

        private void SetEllipseColor(string position, SolidColorBrush color)
        {
            if (_teethMap.ContainsKey(position))
            {
                _teethMap[position] = color;
            }
            else
            {
                _teethMap.TryAdd(position, color);
            }

            switch (position)
            {
                case ToothNames.TR1: EllipseColorTR1 = color; break;
                case ToothNames.TR2: EllipseColorTR2 = color; break;
                case ToothNames.TR3: EllipseColorTR3 = color; break;
                case ToothNames.TR4: EllipseColorTR4 = color; break;
                case ToothNames.TR5: EllipseColorTR5 = color; break;
                case ToothNames.TR6: EllipseColorTR6 = color; break;
                case ToothNames.TR7: EllipseColorTR7 = color; break;
                case ToothNames.TR8: EllipseColorTR8 = color; break;
                case ToothNames.TL1: EllipseColorTL1 = color; break;
                case ToothNames.TL2: EllipseColorTL2 = color; break;
                case ToothNames.TL3: EllipseColorTL3 = color; break;
                case ToothNames.TL4: EllipseColorTL4 = color; break;
                case ToothNames.TL5: EllipseColorTL5 = color; break;
                case ToothNames.TL6: EllipseColorTL6 = color; break;
                case ToothNames.TL7: EllipseColorTL7 = color; break;
                case ToothNames.TL8: EllipseColorTL8 = color; break;

                case ToothNames.BR1: EllipseColorBR1 = color; break;
                case ToothNames.BR2: EllipseColorBR2 = color; break;
                case ToothNames.BR3: EllipseColorBR3 = color; break;
                case ToothNames.BR4: EllipseColorBR4 = color; break;
                case ToothNames.BR5: EllipseColorBR5 = color; break;
                case ToothNames.BR6: EllipseColorBR6 = color; break;
                case ToothNames.BR7: EllipseColorBR7 = color; break;
                case ToothNames.BR8: EllipseColorBR8 = color; break;
                case ToothNames.BL1: EllipseColorBL1 = color; break;
                case ToothNames.BL2: EllipseColorBL2 = color; break;
                case ToothNames.BL3: EllipseColorBL3 = color; break;
                case ToothNames.BL4: EllipseColorBL4 = color; break;
                case ToothNames.BL5: EllipseColorBL5 = color; break;
                case ToothNames.BL6: EllipseColorBL6 = color; break;
                case ToothNames.BL7: EllipseColorBL7 = color; break;
                case ToothNames.BL8: EllipseColorBL8 = color; break;
            }

            ChangeEllipseProperties();
        }

        private void OnDeleteChip(object parameter)
        {
            if (parameter is ChipModel chip)
            {
                TeethCollection.Remove(chip);
            }
        }

        private async void SetupMedicineCollectionAsync()
        {
            IMedicineDao dao = new MedicineDaoImpl();
            List<Medicine> medicineList = await dao.GetAllAsync();

            if (medicineList != null)
            {
                foreach (var medicine in medicineList)
                {
                    MedicineCollection.Add(medicine);
                }
            }
        }

        public void OnReceiveParameter(object parameter)
        {
            if(parameter is Patient patient)
            {
                Patient = patient;
                PatientName = patient.FirstName + " " + patient.LastName;
            }
        }
    }
}


// Congratulations, you've scrolled so far down you've reached the Balrog! (along with a certain someone)     :)
/*
                        ,---.
                       /    |
                      /     |
                     /      |
                    /       |
               ___,'        |
             <  -'          :
              `-.__..--'``-,_\_
                 |o/ ` :,.)_`>                      
                 :/ `     ||/)
                 (_.).__,-` |\
  Fly you fool!  /( `.``   `| :
                 \'`-.)  `  ; ;
                 | `       /-<
                 |     `  /   `.
 ,-_-..____     /|  `    :__..-'\
/,'-.__\\  ``-./ :`      ;       \
`\ `\  `\\  \ :  (   `  /  ,   `. \
  \` \   \\   |  | `   :  :     .\ \
   \ `\_  ))  :  ;     |  |      ): :
  (`-.-'\ ||  |\ \   ` ;  ;       | |
   \-_   `;;._   ( `  /  /_       | |
    `-.-.// ,'`-._\__/_,'         ; |
       \:: :     /     `     ,   /  |
        || |    (        ,' /   /   |
        ||                ,'   / SSt|
*/