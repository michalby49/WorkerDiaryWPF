using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WorkerDiaryWPF.Models.Domains;

namespace WorkerDiaryWPF.Models.Configuration
{
    class ShiftConfiguration : EntityTypeConfiguration<Shift>
    {
        public ShiftConfiguration()
        {
            ToTable("dbo.Shifts");

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Name).HasMaxLength(20).IsRequired();
        }
        

    }
}
