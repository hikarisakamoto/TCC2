using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Web
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
    }
}