using Daylon.RateMeApp.Application.Interfaces.FeedPosts;
using Daylon.RateMeApp.Application.Interfaces.Products;
using Daylon.RateMeApp.Application.Services.FeedPosts;
using Daylon.RateMeApp.Application.Services.Products;
using Daylon.RateMeApp.Application.UseCases.Product;
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
            services.AddScoped<IProductUseCase, ProductUseCase>();
            services.AddScoped<IFeedPostService, FeedPostService>();
        }
    }
}