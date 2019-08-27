using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using m = Model;

namespace DataAccess
{
    public class Category
    {
        public async static Task<IEnumerable<FinancialManagementSystem.Models.Category>> Get()
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryAsync<FinancialManagementSystem.Models.Category>(DbAccess.SelectAll<Category>());
            }
        }

        public async static Task<FinancialManagementSystem.Models.Category> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                return await db.QueryFirstOrDefaultAsync<FinancialManagementSystem.Models.Category>(DbAccess.Select<Category>(),
                     new { CategoryId = id });
            }
        }

        public async static Task Insert(Category obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<Category>(), obj);
            }
        }

        public async static Task Update(Category obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<Category>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<Category>(),
                    new { CategoryId = id });
            }
        }
    }
}
