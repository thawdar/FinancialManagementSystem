using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Shared;
using System.Linq;

namespace DataAccess
{
    public class Transaction 
    {
        public async static Task<IEnumerable<FinancialManagementSystem.Models.Transaction>> Get()
        {
            IEnumerable<FinancialManagementSystem.Models.Category> categories = await Category.Get();
            IEnumerable<FinancialManagementSystem.Models.Account> accounts = await Account.Get();

            using (var db = DbAccess.ConnectionFactory())
            {
                IEnumerable<FinancialManagementSystem.Models.Transaction> transactions = await db.QueryAsync<FinancialManagementSystem.Models.Transaction>(DbAccess.SelectAll<FinancialManagementSystem.Models.Transaction>());
                foreach (var t in transactions)
                {
                    t.Category = categories.FirstOrDefault(c => c.CategoryId == t.CategoryId);
                    t.Account = accounts.FirstOrDefault(a => a.AccountId == t.AccountId);
                }

                return transactions;
            }
        }

        public async static Task<FinancialManagementSystem.Models.Transaction> Get(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                FinancialManagementSystem.Models.Transaction transaction = await db.QueryFirstOrDefaultAsync<FinancialManagementSystem.Models.Transaction>(DbAccess.Select<FinancialManagementSystem.Models.Transaction>(),
                     new { TransactionId = id });

                transaction.Category = await Category.Get(transaction.CategoryId);
                transaction.Account = await Account.Get(transaction.AccountId);

                return transaction;
            }
        }

        public async static Task Insert(FinancialManagementSystem.Models.Transaction obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Insert<FinancialManagementSystem.Models.Transaction>(), obj);
            }
        }

        public async static Task Update(FinancialManagementSystem.Models.Transaction obj)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Update<FinancialManagementSystem.Models.Transaction>(), obj);
            }
        }

        public async static Task Delete(Guid id)
        {
            using (var db = DbAccess.ConnectionFactory())
            {
                await db.ExecuteAsync(DbAccess.Delete<Transaction>(),
                    new { TransactionId = id });
            }
        }
    }
}
