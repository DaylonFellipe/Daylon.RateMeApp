using Daylon.RateMeApp.Application.Interfaces.Products;
using Daylon.RateMeApp.Application.UseCases.Product.Validators;
using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Domain.Entity.Enum;
using Daylon.RateMeApp.Domain.Interfaces.Repositories;
using Daylon.RateMeApp.Exceptions;
using Daylon.RateMeApp.Exceptions.ExceptionBases;
using FluentValidation;

namespace Daylon.RateMeApp.Application.UseCases.Product
{
    public class ProductUseCase(IProductRepository productRepository) : IProductUseCase
    {
        private readonly IProductRepository _productRepository = productRepository;

        // Post
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

        // Put
        public async Task<Domain.Entity.Product> ExecuteUpdateProductAsync(RequestUpdateProductJson request)
        {
            // Get existing product
            var product = await _productRepository.GetProductByIdAsync(request.Id) ??
                throw new KeyNotFoundException(string.Format(ResourceMessagesException.PRODUCT_ID_NO_FOUND));

            // Validate
            await ValidateRequest(request, new UpdateProductValidator());

            // Update Properties
            if (!string.IsNullOrWhiteSpace(request.Name)) product.Name = request.Name;
            if (!string.IsNullOrWhiteSpace(request.Description)) product.Description = request.Description;

            if (request.Price is not null && request.Price >= 0) product.Price = request.Price;
            if (request.Rating is not null && request.Rating >= 0 && request.Rating <= 5) product.Rating = request.Rating;

            if (!string.IsNullOrWhiteSpace(request.ImageUrl)) product.ImageUrl = request.ImageUrl;

            if (request.Category is not null && Enum.IsDefined(request.Category.Value)) product.Category = (ProductCategoryEnum)request.Category;
            if (request.SubCategory is not null && Enum.IsDefined(request.SubCategory.Value)) product.SubCategory = (ProductSubCategoryEnum)request.SubCategory;

            if (request.SupplierOption is not null && Enum.IsDefined(request.SupplierOption.Value)) product.SupplierOption = request.SupplierOption;
            if (!string.IsNullOrWhiteSpace(request.SupplierPersonalizedName)) product.SupplierPersonalizedName = request.SupplierPersonalizedName;

            // Save
            await _productRepository.UpdateProductAsync(product);

            return product;
        }

        // Auxiliary Methods
        private static async Task ValidateRequest<T>(T request, AbstractValidator<T> validator)
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