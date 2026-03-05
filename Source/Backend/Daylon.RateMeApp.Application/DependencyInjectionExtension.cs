using Daylon.RateMeApp.Application.Interfaces.Products;
using Daylon.RateMeApp.Application.Services.Products;
using Microsoft.Extensions.DependencyInjection;

namespace Daylon.RateMeApp.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            AddServices(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}