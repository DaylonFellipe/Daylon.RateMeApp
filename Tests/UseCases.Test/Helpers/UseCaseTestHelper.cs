using CommonTestUtilities.Repositories.FeedPost;
using CommonTestUtilities.Repositories.Product;
using Daylon.RateMeApp.Application.UseCases.FeedPost;
using Daylon.RateMeApp.Application.UseCases.Product;
using Microsoft.Extensions.Configuration;

// The request properties are tested in Validator.Test - empty fields, invalid requests...

namespace UseCases.Test.Helpers
{
    public class UseCaseTestHelper
    {
        private readonly ProductRepositoryInMemory _productRepository = new();
        private readonly FeedPostRepositoryInMemory _postRepository = new();

        public ProductUseCase ProductCreateUseCase()
        {
            _ = new ConfigurationBuilder().Build();

            return new ProductUseCase(_productRepository);
        }

        public FeedPostUseCase FeedPostCreateUseCase()
        {
            _ = new ConfigurationBuilder().Build();

            return new FeedPostUseCase(_postRepository, _productRepository);
        }
    }
}