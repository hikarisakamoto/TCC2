using Microsoft.EntityFrameworkCore;
using Sakamoto.TCC2.CSU.Web.Models.EventStore;
using Sakamoto.TCC2.CSU.Web.Models.MedicalRecord;
using Sakamoto.TCC2.CSU.Web.Models.Patients;
using Sakamoto.TCC2.CSU.Web.Models.Practitioners;

namespace Sakamoto.TCC2.CSU.Web.Data
{
    public class CSUContext : DbContext
    {
        public CSUContext(DbContextOptions<CSUContext> options)
            : base(options)
        {
        }

        public DbSet<AddressViewModel> AddressViewModel { get; set; }

        public DbSet<MedicalRecordViewModel> MedicalRecordViewModel { get; set; }

        public DbSet<PatientViewModel> PatientViewModel { get; set; }

        public DbSet<PractitionerViewModel> PractitionerViewModel { get; set; }

        public DbSet<StoredEventViewModel> StoredEventViewModel { get; set; }
    }
}