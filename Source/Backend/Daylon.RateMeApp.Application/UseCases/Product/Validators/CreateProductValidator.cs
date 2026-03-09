using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Domain.Entity.Enum;
using FluentValidation;

namespace Daylon.RateMeApp.Application.UseCases.Product.Validators
{
    public class CreateProductValidator : AbstractValidator<RequestCreateProductJson>
    {
        public CreateProductValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Product name must not exceed 200 characters.");

            RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(1000).WithMessage("Product name must not exceed 1000 characters.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be a positive value.");

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5).WithMessage("Rating must be between 0 and 5.");

            RuleFor(x => x.Category)
                .IsInEnum().WithMessage("Invalid category is required")
                .Must(category => Enum.IsDefined(typeof(ProductCategoryEnum), category)).WithMessage("Invalid category.");

            RuleFor(x => x.SubCategory)
                .IsInEnum().WithMessage("Valid subcategory is required")
                .Must(subCategory => Enum.IsDefined(typeof(ProductSubCategoryEnum), subCategory)).WithMessage("Invalid subcategory.");

            RuleFor(x => x.SupplierOption)
                .Must(supplierOption => supplierOption == null ||
                Enum.IsDefined(typeof(SupplierOptionsEnum), supplierOption)).WithMessage("Invalid supplier option.");

            RuleFor(x => x.SupplierPersonalizedName)
                .MaximumLength(200).WithMessage("Supplier personalized name must not exceed 200 characters.")
                .When(x => x.SupplierOption == null || x.SupplierOption == SupplierOptionsEnum.Indefinite)
                .WithMessage("Supplier personalized name is required when supplier option is not indefinite.");
        }
    }
}