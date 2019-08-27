using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;

namespace FinancialManagementSystem.Models.DB
{
    public partial class LoginContext : DbContext
    {
        public LoginContext()
        {

        }

        public LoginContext(DbContextOptions<LoginContext> options): base (options)
        {

        }
        
        public virtual  DbSet<LoginUser> Login { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.Query<LoginUser>();
        }

        public async Task<List<LoginUser>> LoginMethodAsync(string usernameVal, string passwordVal)
        {
            // Initialization.
            List<LoginUser> lst = new List<LoginUser>();

            try
            {
                IEnumerable<Models.Profile> profiles = await DataAccess.Profile.Get();
                profiles = profiles.Where(p=> p.LoginId==usernameVal && p.Pwd==passwordVal).ToList();
                foreach(var p in profiles)
                {
                    lst.Add(new LoginUser() { LoginId=p.LoginId, Password=p.Pwd });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Info.
            return lst;
        }
    }
}
