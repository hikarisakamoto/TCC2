using System.Collections.Generic;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Models;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces
{
    public interface IPractitionerRepository : IRepository<Practitioner>
    {
        Practitioner GetByCrm(string crm);
        IEnumerable<Practitioner> GetAllPractitioners();
    }
}