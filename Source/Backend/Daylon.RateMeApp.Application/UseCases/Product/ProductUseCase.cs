using Daylon.RateMeApp.Application.Interfaces.Products;
using Daylon.RateMeApp.Application.UseCases.Product.Validators;
using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Daylon.RateMeApp.Exceptions.ExceptionBases;
using FluentValidation;

namespace Daylon.RateMeApp.Application.UseCases.Product
{
    public class ProductUseCase(IProductRepository productRepository) : IProductUseCase
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<Domain.Entity.Product> ExecuteCreateProductAsync(RequestCreateProductJson request)
        {
            // Validate
            await ValidateRequest(request, new CreateProductValidator());

            // Map
            var product = new Domain.Entity.Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Rating = request.Rating,
                ImageUrl = request.ImageUrl,
                Category = request.Category,
                SubCategory = request.SubCategory,
                SupplierOption = request.SupplierOption,
                SupplierPersonalizedName = request.SupplierPersonalizedName
            };

            // Save
            await _productRepository.CreateProductAsync(product);

            return product;
        }

        // Auxiliary Methods
        private async Task ValidateRequest<T>(T request, AbstractValidator<T> validator)
        {
            var result = await validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }
    }
}