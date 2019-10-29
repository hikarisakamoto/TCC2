using System;
using Dapper;
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
            const string sql = "SELECT * FROM PRACTITIONERS P WHERE P.CRM LIKE '%@crm%'";
            return Context.Database.GetDbConnection().QueryFirstOrDefault<Practitioner>(sql, new {crm});
        }

        public override Practitioner GetById(Guid id)
        {
            const string sql = "SELECT * FROM PRACTITIONERS P WHERE P.IDM = @id";
            return Context.Database.GetDbConnection().QueryFirstOrDefault<Practitioner>(sql, new {id});
        }
    }
}