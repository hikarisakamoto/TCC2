using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Sakamoto.TCC2.CSU.Web.Models.Patients;

namespace Sakamoto.TCC2.CSU.Web.Models
{
    public class SakamotoTCC2CSUWebContext : DbContext
    {
        private readonly IHttpClientFactory _clientFactory;

        public SakamotoTCC2CSUWebContext(DbContextOptions<SakamotoTCC2CSUWebContext> options)
            : base(options)
        {
        }


        public DbSet<PatientViewModel> PatientViewModel { get; set; }
    }
}