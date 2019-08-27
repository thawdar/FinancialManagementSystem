using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using m = Model;

namespace DataAccess
{
    public class Subscription
    {
        public async static Task<IEnumerable<FinancialManagementSystem.Models.Subscription>> Get()
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<FinancialManagementSystem.Models.Subscription>(DbAccess.SelectAll<FinancialManagementSystem.Models.Subscription>());
            }
        }

        public async static Task<FinancialManagementSystem.Models.Subscription> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryFirstOrDefaultAsync<FinancialManagementSystem.Models.Subscription>(DbAccess.Select<FinancialManagementSystem.Models.Subscription>(),
                     new { SubscriptionId = id });
            }
        }

        public async static Task Insert(FinancialManagementSystem.Models.Subscription obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<FinancialManagementSystem.Models.Subscription>(), obj);
            }
        }

        public async static Task Update(FinancialManagementSystem.Models.Subscription obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<FinancialManagementSystem.Models.Subscription>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<Subscription>(),
                    new { SubscriptionId = id });
            }
        }
    }
}
