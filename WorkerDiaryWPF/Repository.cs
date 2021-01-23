using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerDiaryWPF.Models.Conventer;
using WorkerDiaryWPF.Models.Domains;
using WorkerDiaryWPF.Models.Wrappers;
using System.Data.Entity;

namespace WorkerDiaryWPF
{
    public class Repository
    {
        public List<Shift> GetShifts()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Shifts.ToList();
            }
        }

        public List<EmployeeWrapper> GetEmployees(int shiftId)
        {
            using (var context = new ApplicationDbContext())
            {
                var employees = context.Employees
                    .Include(x => x.Shift)
                    .AsQueryable();

                if (shiftId != 0)
                    employees = employees.Where(x => x.ShiftId == shiftId);

                return employees
                    .ToList()
                    .Select(x => x.ToWrapper())
                    .ToList();

            }

        }

        public void DeleteEmployee(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var employeeToDelete = context.Employees.Find(id);
                context.Employees.Remove(employeeToDelete);
                context.SaveChanges();
            };

        }
        public void DismissEmployee(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var employeeToDismiss = context.Employees.Find(id);
                employeeToDismiss.Hired = false;
                context.SaveChanges();
            };

        }
        public void UpdateEmployee(EmployeeWrapper employeeWrapper)
        {
            var employee = employeeWrapper.ToDao();


            using (var context = new ApplicationDbContext())
            {
                UpdateEmployeesPropertis(context, employee);

                context.SaveChanges();
            }
        }

        private void UpdateEmployeesPropertis(ApplicationDbContext context, Employee employee)
        {
            var employeeToUpdate = context.Employees.Find(employee.Id);
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.Comments = employee.Comments;
            employeeToUpdate.Job = employee.Job;
            employeeToUpdate.Earnings = employee.Earnings;
            employeeToUpdate.DateOfEmployment = employee.DateOfEmployment;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.Phone = employee.Phone;
            employeeToUpdate.Hired = employee.Hired;
            employeeToUpdate.ShiftId = employee.ShiftId;
        }



        public void AddEmployee(EmployeeWrapper employeeWrapper)
        {
            employeeWrapper.Hired = true;
            var employee = employeeWrapper.ToDao();


            using (var context = new ApplicationDbContext())
            {
                var dbEmployee = context.Employees.Add(employee);


                context.SaveChanges();
            }
        }
    }
}
