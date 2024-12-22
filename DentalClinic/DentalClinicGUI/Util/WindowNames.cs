using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicGUI.Util
{
    internal class WindowNames
    {
        public const string LoginWindow = "LoginWindow";

        // Doctor windows
        public const string DoctorMainWindow = "DoctorMainWindow";
        public const string AddAppointmentWindow = "AddAppointmentWindow";
        public const string AddPatientWindow = "AddPatientWindow";
        public const string AddMedicineWindow = "AddMedicineWindow";
        public const string AddTreatmentWindow = "AddTreatmentWindow";
        public const string ReceiptWindow = "ReceiptWindow";

        // Admin windows
        public const string AdminMainWindow = "AdminMainWindow";
        public const string AddUserWindow = "AddUserWindow";
        public const string UpdateUserWindow = "UpdateUserWindow";
        public const string UpdateMedicineWindow = "UpdateMedicineWindow";

        // --------------------------------------------------------------------------------------------

        // Doctor pages
        public const string DashboardPage = "DashboardPage";
        public const string AppointmentsPage = "AppointmentsPage";
        public const string PatientsPage = "PatientsPage";
        public const string DentistsPage = "DentistsPage";
        public const string MedicinePage = "MedicinePage";
        public const string PaymentPage = "PaymentPage";
        public const string SettingsPage = "SettingsPage";

        // Admin pages
        public const string UsersPage = "UsersPage";
        public const string StoragePage = "StoragePage";
    }
}
