using Microsoft.EntityFrameworkCore;
using Mng.Core.Entities;

namespace Mng.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RoleForEmployee> Roles { get; set; }
        public DbSet<TypesOfRoles> TypesOfRoles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_db");

        }

    }
}
