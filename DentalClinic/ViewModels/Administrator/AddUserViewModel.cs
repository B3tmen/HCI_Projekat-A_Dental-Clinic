using Models.Dao.Implementations;
using Models.Dao.Interfaces;
using Models.Enums;
using Models.Factory;
using Models.Model;
using Mysqlx.Datatypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModels.Commands;
using ViewModels.Services;
using ViewModels.Util;

namespace ViewModels.Administrator
{
    public class AddUserViewModel : ViewModelBase
    {
        private ObservableCollection<UserRole>  _roleItems;
        private User                            _user;
        private Models.Model.Doctor             _doctor;
        private UserRole                        _selectedRole;
        private Gender                          _selectedGender;

        public AddUserViewModel() 
        {
            RoleItems = new();
            GenderItems = new();
            User = new();
            Doctor = new();
            _selectedRole = UserRole.Administrator;

            AddUserCommand = new RelayCommand(execute => OnAddUser());

            SetupRoleCollection();
            SetupGenderCollection();
        }

        public ICommand AddUserCommand { get; init; }

        public User User 
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
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

        public ObservableCollection<UserRole> RoleItems
        {
            get => _roleItems;
            set
            {
                _roleItems = value;
                OnPropertyChanged(nameof(RoleItems));
            }
        }

        public ObservableCollection<Gender> GenderItems { get; set; }
        
        public UserRole SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                OnPropertyChanged(nameof(SelectedRole));
                OnPropertyChanged(nameof(DoctorRoleSelected));
            }
        }

        public Gender SelectedGender 
        {
            get => _selectedGender;
            set
            {
                _selectedGender = value;
                OnPropertyChanged(nameof(SelectedGender));
            }
        }


        public bool DoctorRoleSelected => SelectedRole == UserRole.Doctor;



        private async void OnAddUser()
        {
            if (CheckEmptyFields())
            {
                var answer = MessageBoxShower.ShowQuestionBox(LanguageService.GetString("Question_AddUser"), LanguageService.GetString("PressYes"));

                if (answer == MessageBoxResult.Yes)
                {
                    bool inserted = false;
                    IUserDao dao = new UserDaoImpl();
                    Dictionary<string, object> data = new() {
                        { "userId", 0 },
                        { "username", User.Username },
                        { "passwordHash", User.Password },
                        { "firstName", User.FirstName },
                        { "lastName", User.LastName },
                        { "email", User.Email },
                        { "isActive", User.IsActive },
                        { "languageId", 1 },    // default light theme and english
                        { "themeId", 1 },

                        { "specialization", Doctor.Specialization },
                        { "phoneNumber", Doctor.PhoneNumber },
                        { "gender", Doctor.Gender },
                        { "salary", Doctor.Salary },
                    };

                    User user = UserFactoryRegistry.CreateUser(SelectedRole, data);
                    inserted = await dao.InsertAsync(user);
                    if (inserted)
                    {
                        MessageBoxShower.ShowSuccessBox(LanguageService.GetString("Success_AddUser"), LanguageService.GetString("PressOK"));
                    }
                    else
                    {
                        MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error"), LanguageService.GetString("ErrorOccured"));
                    }
                }
            }

            
        }

        private void SetupRoleCollection()
        {
            RoleItems.Add(UserRole.Administrator);
            RoleItems.Add(UserRole.Doctor);
        }

        private void SetupGenderCollection()
        {
            GenderItems.Add(Gender.Male);
            GenderItems.Add(Gender.Female);
        }

        private bool CheckEmptyFields()
        {
            bool check = true;

            if(string.IsNullOrEmpty(User.Username) || string.IsNullOrEmpty(User.Password) || string.IsNullOrEmpty(User.FirstName) || string.IsNullOrEmpty(User.LastName) ||
               string.IsNullOrEmpty(User.Email)){

                MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_UserEmptyFields"), LanguageService.GetString("TryAgain"));
                check = false;

            }
            if(SelectedRole == UserRole.Doctor)
            {
                if(string.IsNullOrEmpty(Doctor.Specialization) || string.IsNullOrEmpty(Doctor.PhoneNumber) || Doctor.Salary == 0)
                {
                    MessageBoxShower.ShowErrorBox(LanguageService.GetString("Error_DoctorEmptyFields"), LanguageService.GetString("TryAgain"));
                    check = false;
                }
            }

            return check;
        }
    }
}
