using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerDiaryWPF.Models.Domains
{
    public class Employee
    {
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
        public int ShiftId { get; set; }

        public Shift Shift { get; set; }
       

    }
}
