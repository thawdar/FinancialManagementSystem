using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using m = Model;

namespace DataAccess
{
    public class Profile
    {
        public async static Task<IEnumerable<FinancialManagementSystem.Models.Profile>> Get()
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<FinancialManagementSystem.Models.Profile>(DbAccess.SelectAll<FinancialManagementSystem.Models.Profile>());
            }
        }

        public async static Task<FinancialManagementSystem.Models.Profile> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryFirstOrDefaultAsync<FinancialManagementSystem.Models.Profile>(DbAccess.Select<FinancialManagementSystem.Models.Profile>(),
                     new { ProfileId = id });
            }
        }

        public async static Task Insert(FinancialManagementSystem.Models.Profile obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<FinancialManagementSystem.Models.Profile>(), obj);
            }
        }

        public async static Task Update(FinancialManagementSystem.Models.Profile obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<FinancialManagementSystem.Models.Profile>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<FinancialManagementSystem.Models.Profile>(),
                    new { ProfileId = id });
            }
        }
    }
}
