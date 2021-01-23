using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerDiaryWPF.Models.Domains;
using WorkerDiaryWPF.Models.Wrappers;

namespace WorkerDiaryWPF.Models.Conventer
{
    public static class EmployeeConventer
    {
        public static EmployeeWrapper ToWrapper(this Employee model)
        {
            return new EmployeeWrapper
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Comments = model.Comments,
                Job = model.Job,
                Earnings = model.Earnings,
                DateOfEmployment = model.DateOfEmployment,
                Email = model.Email,
                Phone = model.Phone,
                Hired = model.Hired,
                Shift = new ShiftWrapper
                {
                    Id = model.Shift.Id,
                    Name = model.Shift.Name
                },
                

            };

        }

        public static Employee ToDao(this EmployeeWrapper model)
        {
            return new Employee
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                ShiftId = model.Shift.Id,
                Comments = model.Comments,
                Job = model.Job,
                Earnings = model.Earnings,
                DateOfEmployment = model.DateOfEmployment,
                Email = model.Email,
                Phone = model.Phone,
                Hired = model.Hired,
            };
        }
    }
}
