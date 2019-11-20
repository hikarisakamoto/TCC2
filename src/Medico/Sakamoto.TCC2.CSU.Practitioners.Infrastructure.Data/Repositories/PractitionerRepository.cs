using System;
using System.Collections.Generic;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Models;
using Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Context;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Repositories
{
    public class PractitionerRepository : Repository<Practitioner>, IPractitionerRepository
    {
        public PractitionerRepository(PractitionerContext context) : base(context)
        {
        }

        public Practitioner GetByCrm(string crm)
        {
            const string sql = "SELECT * FROM PRACTITIONERS P WHERE P.CRM LIKE @crm";
            return Context.Database.GetDbConnection().QueryFirstOrDefault<Practitioner>(sql, new { crm });
        }

        public IEnumerable<Practitioner> GetAllPractitioners()
        {
            const string sql = "SELECT * FROM PRACTITIONERS";
            return Context.Database.GetDbConnection().Query<Practitioner>(sql);
        }

        public override Practitioner GetById(Guid id)
        {
            const string sql = "SELECT * FROM PRACTITIONERS P WHERE P.ID = @id";
            return Context.Database.GetDbConnection().QueryFirstOrDefault<Practitioner>(sql, new { id });
        }
    }
}