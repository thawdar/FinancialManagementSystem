using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using Model = FinancialManagementSystem.Models;

namespace DataAccess
{
    public class Account
    {
        public async static Task<IEnumerable<FinancialManagementSystem.Models.Account>> Get()
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<FinancialManagementSystem.Models.Account>(DbAccess.SelectAll<Account>());
            }
        }

        public async static Task<FinancialManagementSystem.Models.Account> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryFirstOrDefaultAsync<FinancialManagementSystem.Models.Account>(DbAccess.Select<FinancialManagementSystem.Models.Account>(),
                     new { AccountId = id });
            }
        }

        public async static Task Insert(FinancialManagementSystem.Models.Account obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<Account>(), obj);
            }
        }

        public async static Task Update(FinancialManagementSystem.Models.Account obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<FinancialManagementSystem.Models.Account>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<Account>(),
                    new { AccountId = id });
            }
        }
    }
}
