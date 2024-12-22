using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Interfaces;
using ViewModels.Services;
using ViewModels.Util;

namespace ViewModels.Doctor
{
    public class DoctorMainViewModel : ViewModelBase, IParameterReceiver
    {
        private Page                        _childPage;
        private Models.Model.Doctor         _doctor;
        private string                      _doctorFullName;
        private readonly INavigationService _navigationService;
        private Window                      _window;


        public DoctorMainViewModel(INavigationService navigationService, Window window)
        {
            _navigationService = navigationService;
            _window = window;
            UserLanguage = null;
            UserTheme = null;
            UserFont = null;

            SetupCommands();
        }


        public ICommand ShowDashboardCommand    { get; private set; }
        public ICommand ShowAppointmentsCommand { get; private set; }
        public ICommand ShowPatientsCommand     { get; private set; }
        public ICommand ShowDoctorsCommand      { get; private set; }
        public ICommand ShowMedicineCommand     { get; private set; }
        public ICommand ShowPaymentCommand      { get; private set; }
        public ICommand ShowSettingsCommand     { get; private set; }
        public ICommand LogoutCommand           { get; private set; }

        public Theme    UserTheme       { get; private set; }
        public Language UserLanguage    { get; private set; }
        public UserFont UserFont        { get; private set; }

        public Page ChildPage { 
            get => _childPage;
            set
            {
                _childPage = value;
                OnPropertyChanged(nameof(ChildPage));
            }
        }

        public Models.Model.Doctor Doctor
        {
            get => _doctor;
            set
            {
                _doctor = value;
                OnPropertyChanged(nameof(Doctor));  
            }
        }

        public string DoctorFullName
        {
            get => _doctorFullName;
            set
            {
                _doctorFullName = value;
                OnPropertyChanged(nameof(DoctorFullName));
            }
        }


        private void SetupCommands()
        {
            ShowDashboardCommand = new RelayCommand(execute => OnShowDashboard());
            ShowAppointmentsCommand = new RelayCommand(execute => OnShowAppointments());
            ShowPatientsCommand = new RelayCommand(execute => OnShowPatients());
            ShowDoctorsCommand = new RelayCommand(execute => OnShowDoctors());
            ShowMedicineCommand = new RelayCommand(execute => OnShowMedicine());
            ShowPaymentCommand = new RelayCommand(execute => OnShowPayment());
            ShowSettingsCommand = new RelayCommand(execute => OnShowSettings());
            LogoutCommand = new RelayCommand(execute => OnLogout());
        }

        private void OnShowDashboard()
        {
            ChildPage = _navigationService.NavigateToPage("DashboardPage", _doctor);
        }
        private void OnShowAppointments()
        {
            ChildPage = _navigationService.NavigateToPage("AppointmentsPage");
        }
        private void OnShowPatients()
        {
            ChildPage = _navigationService.NavigateToPage("PatientsPage");
        }
        private void OnShowDoctors()
        {
            ChildPage = _navigationService.NavigateToPage("DentistsPage");
        }
        private void OnShowMedicine()
        {
            ChildPage = _navigationService.NavigateToPage("MedicinePage");
        }
        private void OnShowPayment()
        {
            ChildPage = _navigationService.NavigateToPage("PaymentPage");
        }
        private void OnShowSettings()
        {
            ChildPage = _navigationService.NavigateToPage("SettingsPage", _doctor);
        }

        private void OnLogout()
        {
            var answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_Logout"), LanguageService.GetString("PressYes"));
            if(answer == MessageBoxResult.Yes)
            {
                _navigationService.NavigateToWindow("LoginWindow");
                _window.Hide();
            }
        }

        public void OnReceiveParameter(object parameter)
        {
            if (parameter != null)
            {
                if (parameter is Models.Model.Doctor doctor)
                {
                    _doctor = doctor;
                    DoctorFullName = "Dr " + _doctor.FirstName + " " + _doctor.LastName + ", " + _doctor.Specialization;
                    SetupUserPreferences(_doctor.LanguageId, _doctor.ThemeId, _doctor.FontId);
                }
            }
            
        }

        private async void SetupUserPreferences(int languageId, int themeId, int fontId)
        {
            ILanguageDao languageDao = new LanguageDaoImpl();
            IThemeDao themeDao = new ThemeDaoImpl();
            IFontDao fontDao = new FontDaoImpl();

            Language language = await languageDao.GetAsync(languageId);
            Theme theme = await themeDao.GetAsync(themeId);
            UserFont font = await fontDao.GetAsync(fontId);

            if (language != null)
            {
                UserLanguage = language;
            }
            if (theme != null)
            {
                UserTheme = theme;
            }
            if(font != null)
            {
                UserFont = font;
            }
        }
    }
}
