using ApiCompany.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCompany.Infraestructure
{
    public class CompanyContext : DbContext
    {

        public DbSet<Company> Companys { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }

        public CompanyContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=DatabaseCompany;" +
                "User Id=postgres;" +
                "Password=123456;"
            );
    }
}
