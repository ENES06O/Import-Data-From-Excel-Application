using Microsoft.EntityFrameworkCore;

namespace ImportDataFromExcelApplication2.Models
{
    public class PatientDbContext:DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {

        }
        public DbSet<Patient> Patients { get; set; }

    }
}
