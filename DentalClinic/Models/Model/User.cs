using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{

    public class User : INotifyPropertyChanged
    {
        private int         _userId;
        private string      _username;
        private string      _password;
        private string      _firstName;
        private string      _lastName;
        private string      _email;
        private UserRole    _role;
        private bool        _isActive;
        private int         _languageId;
        private int         _themeId;
        private int         _fontId;


        public User() 
        { 
            IsActive = true;
        }

        public User(int userId, string username, string password, string firstName, string lastName, string email, UserRole role, bool isActive, int languageId, int themeId, int fontId)
        {
            UserId = userId;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
            IsActive = isActive;
            LanguageId = languageId;
            ThemeId = themeId;
            FontId = fontId;
        }

        // Copy constructor
        public User(User other)
        {
            UserId = other.UserId;
            Username = other.Username;
            Password = other.Password;
            FirstName = other.FirstName;
            LastName = other.LastName;
            Email = other.Email;
            Role = other.Role;
            IsActive = other.IsActive;
            LanguageId = other.LanguageId;
            ThemeId = other.ThemeId;
            FontId = other.FontId;
        }

        public int      UserId          { get => _userId; init { _userId = value; } }
        public string   Username        { get => _username; set => _username = value; }
        public string   Password        { get => _password; set => _password = value; }
        public string   FirstName       { get => _firstName; set => _firstName = value; }
        public string   LastName        { get => _lastName; set => _lastName = value; }
        public string   Email           { get => _email; set => _email = value; }
        public bool     IsActive        { get => _isActive; set { _isActive = value; OnPropertyChanged(nameof(IsActive)); } }
        public UserRole Role            { get => _role; set => _role = value; }
        public int      LanguageId      { get => _languageId; set => _languageId = value; }
        public int      ThemeId         { get => _themeId; set => _themeId = value; }
        public int      FontId          { get => _fontId; set => _fontId = value; }

        public override string ToString()
        {
            return $"Id: {UserId}, Username: {Username}, FName: {FirstName}, LName: {LastName}, Role: {Role}, Active: {IsActive} | ";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual User DeepCopy()
        {
            return new User(this);
        }

        public virtual void ResetFields()
        {
            Username = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            IsActive = false;
            LanguageId = 0;
            ThemeId = 0;
        }
    }
}
