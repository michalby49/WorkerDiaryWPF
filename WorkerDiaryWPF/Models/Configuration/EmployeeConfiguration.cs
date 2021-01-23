using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerDiaryWPF.Models.Domains;
using System.Data.Entity.ModelConfiguration;

namespace WorkerDiaryWPF.Models.Configuration
{
    class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("dbo.Employees");

            HasKey(x => x.Id);

            Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            Property(x => x.LastName).HasMaxLength(100).IsRequired();
        }
        
    }
}
