using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerDiaryWPF.Models.Wrappers
{
    public class ShiftWrapper : IDataErrorInfo
    {


        public int Id { get; set; }
        public string Name { get; set; }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Id):
                        if (Id == 0)
                        {
                            Error = "Zmiana jest wymagane";
                        }
                        else
                            Error = string.Empty;
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
                return string.IsNullOrWhiteSpace(Error);
            }

        }

    }
}
