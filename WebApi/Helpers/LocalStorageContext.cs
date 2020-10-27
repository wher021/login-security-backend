using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi.Entities;

namespace WebApi.Helpers
{
    public class LocalStorageContext : DataContext
    {

        public LocalStorageContext(IConfiguration configuration) : base(configuration) 
        {
            base.Users.Add(new User()
            {
                FirstName = "Sofia",
                LastName = "G",
                Username = "awdawd",
                Id = 1
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));

            //base.Users.Add(new User()
            //{
            //    FirstName = "Sofia",
            //    LastName = "G",
            //    Username = "awdawd",
            //    Id = 1,
            //});
        }
    }
}