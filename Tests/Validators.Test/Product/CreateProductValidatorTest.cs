using CommonTestUtilities.Requests.Product;
using Daylon.RateMeApp.Application.UseCases.Product.Validators;
using Daylon.RateMeApp.Domain.Entity.Enum;
using Daylon.RateMeApp.Exceptions;
using FluentAssertions;

namespace Validators.Test.Product
{
    public class CreateProductValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        // Name
        [Fact]
        public void Error_Name_Empty()
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();
            request.Name = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(ResourceMessagesException.PRODUCT_NAME_EMPTY));
        }

        [Fact]
        public void Error_Name_Max_Lengh()
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();
            request.Name = GenerateString('a', 201);

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(ResourceMessagesException.PRODUCT_NAME_MAX_LENGH));
        }

        // Description
        [Fact]
        public void Error_Description_Empty()
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();
            request.Description = string.Empty;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(ResourceMessagesException.PRODUCT_DESCRIPTION_EMPTY));
        }

        [Fact]
        public void Error_Description_Max_Lengh()
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();
            request.Description = GenerateString('a', 1001);

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(ResourceMessagesException.PRODUCT_DESCRIPTION_MAX_LENGH));
        }

        // Price
        [Fact]
        public void Error_Price_Min_Lengh()
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();
            request.Price = -1;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(ResourceMessagesException.PRODUCT_PRICE_GREATER_THAN_ZERO));
        }

        // Rating
        [Theory]
        [InlineData(-1)]
        [InlineData(6)]
        public void Error_Rating_Limit_Range(double rating)
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();
            request.Rating = rating;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(ResourceMessagesException.PRODUCT_RATING_LIMIT));
        }

        // Category
        [Fact]
        public void Error_Category_Invalid()
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();
            request.Category = (ProductCategoryEnum)999;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(ResourceMessagesException.PRODUCT_CATEGORY_INVALID));
        }

        // SubCategory
        [Fact]
        public void Error_SubCategory_Invalid()
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();
            request.SubCategory = (ProductSubCategoryEnum)999;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(ResourceMessagesException.PRODUCT_SUB_CATEGORY_INVALID));
        }

        // SupplierOption
        [Fact]
        public void Error_SupplierOption_Invalid()
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();
            request.SupplierOption = (SupplierOptionsEnum)999;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(ResourceMessagesException.PRODUCT_SUPPLIER_OPTIONS_INVALID));
        }

        //SupplierPersonalizedName
        [Fact]
        public void Error_SupplierPersonalized_Max_Lengh()
        {
            var validator = new CreateProductValidator();

            var request = RequestCreateProductJsonBuilder.Build();
            request.SupplierOption = SupplierOptionsEnum.Indefinite;
            request.SupplierPersonalizedName = GenerateString('a', 1000);

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(e => e.ErrorMessage.Contains(ResourceMessagesException.PRODUCT_SUPPLIER_MAX_LENGH));
        }

        // Auxiliary Methods
        private static string GenerateString(char character, int length)
            => new(character, length);
    }
}