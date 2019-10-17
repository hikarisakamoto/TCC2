using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Context
{
    public class PatientContext : DbContext
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        protected PatientContext(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


    }
}