using System.Linq;
using Microsoft.EntityFrameworkCore;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Models;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Context;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Repository
{
    public class PractitionerRepository : Repository<Practitioner>, IPractitionerRepository
    {
        public PractitionerRepository(PractitionerContext context, DbSet<Practitioner> dbSet) : base(context, dbSet)
        {
        }

        public Practitioner GetByCrm(string crm)
        {
            return Context.Practitioners.FirstOrDefault(p => p.CRM.Equals(crm));
        }
    }
}