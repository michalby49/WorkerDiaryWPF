using System;
using System.Data.Entity;
using System.Linq;
using WorkerDiaryWPF.Models.Configuration;
using WorkerDiaryWPF.Models.Domains;
using WorkerDiaryWPF.Models.Wrappers;

namespace WorkerDiaryWPF
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
            : base($@"Server=({ServerWrapper.Address})\{ServerWrapper.Name};Database={ServerWrapper.DataBaseName};User Id={ServerWrapper.DataBaseLogin};Password={ServerWrapper.DataBasePassword};App=EntityFramework")
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Shift> Shifts { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new ShiftConfiguration());


        }

    }

}