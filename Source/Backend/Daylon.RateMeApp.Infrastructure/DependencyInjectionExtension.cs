using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Daylon.RateMeApp.Infrastructure.DataAccess;
using Daylon.RateMeApp.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Daylon.RateMeApp.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddServices(services);
            AddDbContexts(services, configuration);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        private static void AddDbContexts(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServerConnection");

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Connection string is not configured.");

            services.AddDbContext<RateMeAppDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}