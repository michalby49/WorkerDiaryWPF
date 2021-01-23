using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerDiaryWPF.Models.Wrappers
{
    public class EmployeeWrapper : IDataErrorInfo
    {
        public EmployeeWrapper()
        {
            Shift = new ShiftWrapper();
        }


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Comments { get; set; }
        public string Job { get; set; }
        public string Earnings { get; set; }
        public string DateOfEmployment { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Hired { get; set; }
        public ShiftWrapper Shift { get; set; }

        private bool _isFirstNameValid;
        private bool _isLastNameValid;

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(FirstName):
                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            Error = "Imie jest wymagane";
                            _isFirstNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isFirstNameValid = true;
                        }
                        break;

                    case nameof(LastName):
                        if (string.IsNullOrWhiteSpace(LastName))
                        {
                            Error = "Nazwisko jest wymagane";
                            _isLastNameValid = false;
                        }
                        else
                        {
                            Error = string.Empty;
                            _isLastNameValid = true;

                        }
                        break;

                    default:
                        break;
                }

                return Error;
            }
        }
        public string Error { get; set; }
        public bool IsValid
        {
            get
            {
                return _isFirstNameValid && _isLastNameValid && Shift.IsValid;
            }

        }
    }
}
