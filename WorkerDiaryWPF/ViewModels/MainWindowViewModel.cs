using Diary.Commands;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorkerDiaryWPF.Views;
using WorkerDiaryWPF.Models.Wrappers;
using System.Windows;
using WorkerDiaryWPF.Properties;
using WorkerDiaryWPF.Models.Domains;

namespace WorkerDiaryWPF.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        //private Repository _repository = new Repository();

        public MainWindowViewModel()
        {
            //bool settingsAreGood;
            //do
            //{
            //    try
            //    {
            //        settingsAreGood = true;

            //        using (SqlConnection conn = new SqlConnection($@"Server=({ServerWrapper.Address})\{ServerWrapper.Name};Database={ServerWrapper.DataBaseName};User Id={ServerWrapper.DataBaseLogin};Password={ServerWrapper.DataBasePassword};App=EntityFramework"))
            //        {
            //            conn.Open();
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        var openSettings = new SettingsView(false);
            //        settingsAreGood = false;

            //        openSettings.ShowDialog();
            //    }

            //} while (!settingsAreGood);



            AddEmployeeCommand = new RelayCommand(AddEditEmployee);
            EditEmployeeCommand = new RelayCommand(AddEditEmployee, CanEditDeleteEmployee);
            DeleteEmployeeCommand = new AsyncRelayCommand(DeleteEmployee, CanEditDeleteEmployee);
            RefreshEmployeesCommand = new RelayCommand(RefreshEmployee);
            SettingsCommand = new RelayCommand(OpenSettings);

            RefreshDiary();
            //InitGroups();
        }



        private int _selectedShiftId;

        public int SelectedShiftId
        {
            get { return _selectedShiftId; }
            set
            {
                _selectedShiftId = value;
                onPropertyChanged();
            }
        }


        private ObservableCollection<Shift> _shifts;

        public ObservableCollection<Shift> Shifts
        {
            get { return _shifts; }
            set
            {
                _shifts = value;
                onPropertyChanged();
            }
        }

        private EmployeeWrapper _selectedEmployee;

        public EmployeeWrapper SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                onPropertyChanged();
            }
        }
        private ObservableCollection<EmployeeWrapper> _Employees;

        public ObservableCollection<EmployeeWrapper> Employees
        {
            get { return _Employees; }
            set
            {
                _Employees = value;
                onPropertyChanged();
            }
        }
        private void OpenSettings(object obj)
        {
            //var openSettings = new SettingsView(true);

            //openSettings.Closed += OpenSettings_Closed;
            //openSettings.ShowDialog();
        }

        private void OpenSettings_Closed(object sender, EventArgs e)
        {
            Settings.Default.Reload();
        }

        private void RefreshEmployee(object obj)
        {
            RefreshDiary();
        }
        private async Task DeleteEmployee(object obj)
        {
            var metroWindow = Application.Current.MainWindow as MetroWindow;
            var dialog = await metroWindow.ShowMessageAsync("Usuwanie ucznia", $"Czy napewno chcesz usunąć ucznia {SelectedEmployee.FirstName} {SelectedEmployee.LastName}?", MessageDialogStyle.AffirmativeAndNegative);

            if (dialog != MessageDialogResult.Affirmative)
                return;

            //_repository.DeleteStudent(SelectedStudent.Id);

            RefreshDiary();
        }


        private void AddEditEmployee(object obj)
        {
            var addEditStudentWindow = new AddEditEmployeeView(SelectedEmployee);

            addEditStudentWindow.Closed += AddEditEmployeeWindow_Closed;
            addEditStudentWindow.ShowDialog();
        }

        private void AddEditEmployeeWindow_Closed(object sender, System.EventArgs e)
        {
            RefreshDiary();
        }

        private bool CanEditDeleteEmployee(object obj)
        {
            return SelectedEmployee != null;
        }
        //private void InitGroups()
        //{
        //   var groups = _repository.GetGroups();
        //    groups.Insert(0, new Group { Id = 0, Name = "Wszystkie" });

        //    Groups = new ObservableCollection<Group>(groups);

        //    SelectedGroupId = 0;
        //}
        private void RefreshDiary()
        {

            //Employees = new ObservableCollection<EmployeeWrapper>
                //(_repository.GetStudents(SelectedGroupId));

        }

        public ICommand AddEmployeeCommand { get; set; }
        public ICommand EditEmployeeCommand { get; set; }
        public ICommand DismissCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }
        public ICommand RefreshEmployeesCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
    }
}

