using Microsoft.EntityFrameworkCore;
using Sakamoto.TCC2.CSU.Web.Models.Patients;

namespace Sakamoto.TCC2.CSU.Web.Data
{
    public class CSUContext : DbContext
    {
        public CSUContext (DbContextOptions<CSUContext> options)
            : base(options)
        {
        }

        public DbSet<PatientViewModel> PatientViewModel { get; set; }

        public DbSet<AddressViewModel> AddressViewModel { get; set; }
    }
}
