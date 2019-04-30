using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Crm.Infra.Data.Contexto
{
    public class CrmContextFactory : IDesignTimeDbContextFactory<CrmContext>
    {
        public CrmContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CrmContext>();

            var connectionString = configuration.GetConnectionString("CrmConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new CrmContext(optionsBuilder.Options);
        }
    }
}
