using Diary.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WorkerDiaryWPF.Models.Domains;
using WorkerDiaryWPF.Models.Wrappers;

namespace WorkerDiaryWPF.ViewModels
{
    class AddEditEmployeeViewModel : ViewModelBase
    {
        private Repository _repository = new Repository();
        public AddEditEmployeeViewModel(EmployeeWrapper employee = null)
        {
            CloseCommand = new RelayCommand(Close);
            ConfirmCommand = new RelayCommand(Confirm);

            if (employee == null)
            {
                Employee = new EmployeeWrapper();
            }
            else
            {
                Employee = employee;
                IsUpdate = true;
            }

            InitGroups();
        }
        public ICommand CloseCommand { get; set; }
        public ICommand ConfirmCommand { get; set; }

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

        private EmployeeWrapper _employee;

        public EmployeeWrapper Employee
        {
            get { return _employee; }
            set
            {
                _employee = value;
                onPropertyChanged();
            }
        }

        private bool _isUpdate;

        public bool IsUpdate
        {
            get { return _isUpdate; }
            set
            {
                _isUpdate = value;
                onPropertyChanged();
            }
        }
        private void InitGroups()
        {
            var groups = _repository.GetShifts();
            groups.Insert(0, new Shift { Id = 0, Name = "-Brak-" });

            Shifts = new ObservableCollection<Shift>(groups);

            SelectedShiftId = Employee.Shift.Id;
        }
        private void Confirm(object obj)
        {
            if (!Employee.IsValid)
                return;

            if (!IsUpdate)
                AddEmployee();
            else
                UpdateEmployee();

            CloseWindow(obj as Window);
        }

        private void UpdateEmployee()
        {
            _repository.UpdateEmployee(Employee);
        }

        private void AddEmployee()
        {
            _repository.AddEmployee(Employee);
        }

        private void Close(object obj)
        {
            CloseWindow(obj as Window);
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }
    }
}

