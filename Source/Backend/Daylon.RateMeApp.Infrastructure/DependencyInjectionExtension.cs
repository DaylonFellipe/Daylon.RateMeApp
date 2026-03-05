using Microsoft.Extensions.DependencyInjection;

namespace Daylon.RateMeApp.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            //services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}