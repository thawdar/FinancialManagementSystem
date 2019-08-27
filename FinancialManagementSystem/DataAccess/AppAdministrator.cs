using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using m = Model;

namespace DataAccess
{
    public class AppAdministrator
    {
        public async static Task<IEnumerable<FinancialManagementSystem.Models.AppAdministrator>> Get()
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<FinancialManagementSystem.Models.AppAdministrator>(DbAccess.SelectAll<FinancialManagementSystem.Models.AppAdministrator>());
            }
        }

        public async static Task<FinancialManagementSystem.Models.AppAdministrator> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryFirstOrDefaultAsync<FinancialManagementSystem.Models.AppAdministrator>(DbAccess.Select<FinancialManagementSystem.Models.AppAdministrator>(),
                     new { AppAdministratorId = id });
            }
        }

        public async static Task Insert(FinancialManagementSystem.Models.AppAdministrator obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<FinancialManagementSystem.Models.AppAdministrator>(), obj);
            }
        }

        public async static Task Update(FinancialManagementSystem.Models.AppAdministrator obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<FinancialManagementSystem.Models.AppAdministrator>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<FinancialManagementSystem.Models.AppAdministrator>(),
                    new { AppAdministratorId = id });
            }
        }
    }
}
