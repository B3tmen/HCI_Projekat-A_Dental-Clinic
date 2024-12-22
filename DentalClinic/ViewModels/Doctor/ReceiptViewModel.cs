using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Interfaces;
using Models.Model;
using Models.Model.Dto;
using Models.Services.Pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Util;
using System.Windows;
using ViewModels.Services;
using ZstdSharp.Unsafe;

namespace ViewModels.Doctor
{
    public class ReceiptViewModel : ViewModelBase, IParameterReceiver
    {
        private Window      _receiptWindow;
        private string      _totalPrice;
        private string      _patientFullName;
        private Patient     _patient;
        private DateOnly    _todayDate;
        private int _receiptId;

        private Button          _printButton;
        private ScrollViewer    _scrollViewer;


        public ReceiptViewModel(Window currentWindow, Button printButton, ScrollViewer scrollViewer)
        {
            _receiptWindow = currentWindow;
            _printButton = printButton;
            _scrollViewer = scrollViewer;
            _patient = new();
            TodayDate = DateOnly.FromDateTime(DateTime.Now);
            ReceiptDetailsCollection = new();

            GenerateReceiptCommand = new RelayCommand(execute => OnGenerateReceipt());
        }


        public ICommand GenerateReceiptCommand { get; init; }

        public Patient Patient
        {
            get => _patient; 
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        public DateOnly TodayDate { 
            get => _todayDate; 
            set
            {
                _todayDate = value;
                OnPropertyChanged(nameof(TodayDate)); 
            } 
        }

        public Window ReceiptWindow
        {
            get => _receiptWindow;
            set
            {
                _receiptWindow = value;
                //OnPropertyChanged(nameof(ReceiptWindow));
            }
        }

        public ObservableCollection<ReceiptDetailsDto> ReceiptDetailsCollection { get; set; }

        public string PatientFullName 
        {
            get => _patientFullName;
            set
            {
                _patientFullName = value;
                OnPropertyChanged(nameof(PatientFullName));
            }
        }

        public string TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public int ReceiptId
        {
            get => _receiptId;
            set
            {
                _receiptId = value;
                OnPropertyChanged(nameof(ReceiptId));
            }
        }


        private void OnGenerateReceipt()
        {
            // TODO: print pdf... 
            var answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_PrintPdf"), LanguageService.GetString("PressYes"));

            if (answer == MessageBoxResult.Yes)
            {
                _printButton.Visibility = Visibility.Collapsed;     // To not print the button and scrollbar controls on the PDF
                _scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;


                ReceiptService service = new ReceiptService(new PdfSharpGenerator(), Patient.PatientId);
                service.GenerateReceipt(ReceiptDetailsCollection.ToList(), ReceiptWindow);


                MessageBoxShower.ShowSuccessBox("SUCCESS");
                _printButton.Visibility = Visibility.Visible;       // Resetting the visibilities after print is done
                _scrollViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
        }

        private void ResetCollection()
        {
            ReceiptDetailsCollection.Clear();
            TotalPrice = string.Empty;
        }

        private async void SetupReceiptDetailsAsync()
        {
            if(Patient != null)
            {
                IReceiptDao dao = new ReceiptDaoImpl();
                ResetCollection();
                List<ReceiptDetailsDto> receiptDetails = await dao.GetDetailsByPatientId(Patient.PatientId);

                decimal total = 0;
                foreach (var detail in receiptDetails)
                {
                    ReceiptDetailsCollection.Add(detail);
                    total += detail.Subtotal;
                }
                TotalPrice = total + " KM";
                ReceiptId = await dao.GetLastReceiptId();
            }

        }


        public void OnReceiveParameter(object parameter)
        {
            if (parameter is Patient patient)
            {
                Patient = patient;
                PatientFullName = Patient.FirstName + " " + Patient.LastName;

                SetupReceiptDetailsAsync();
            }
        }
    }
}
