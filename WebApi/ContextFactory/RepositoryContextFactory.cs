using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EfCore;

namespace WebApi.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            //configurationBuilder

            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            //dbcontextbuilder

            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                              .UseSqlServer(configuration.GetConnectionString("BookStore"),
                              prj => prj.MigrationsAssembly("WebApi"));

            return new RepositoryContext(builder.Options);
        }
    }
}
