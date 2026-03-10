using Daylon.RateMeApp.Communication.Requests.Product;
using Daylon.RateMeApp.Domain.Entity.Enum;
using Daylon.RateMeApp.Exceptions;
using FluentValidation;

namespace Daylon.RateMeApp.Application.UseCases.Product.Validators
{
    public class CreateProductValidator : AbstractValidator<RequestCreateProductJson>
    {
        public CreateProductValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ResourceMessagesException.PRODUCT_NAME_EMPTY)
                .MaximumLength(200).WithMessage(ResourceMessagesException.PRODUCT_NAME_MAX_LENGH);

            RuleFor(x => x.Description)
            .NotEmpty().WithMessage(ResourceMessagesException.PRODUCT_DESCRIPTION_EMPTY)
            .MaximumLength(1000).WithMessage(ResourceMessagesException.PRODUCT_DESCRIPTION_MAX_LENGH);

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage(ResourceMessagesException.PRODUCT_PRICE_GREATER_THAN_ZERO);

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5).WithMessage(ResourceMessagesException.PRODUCT_RATING_LIMIT);

            RuleFor(x => x.Category)
                .IsInEnum().WithMessage(ResourceMessagesException.PRODUCT_CATEGORY_INVALID_REQUIRED)
                .Must(category => Enum.IsDefined(category)).WithMessage(ResourceMessagesException.PRODUCT_CATEGORY_INVALID);

            RuleFor(x => x.SubCategory)
                .IsInEnum().WithMessage(ResourceMessagesException.PRODUCT_SUB_CATEGORY_INVALID_REQUIRED)
                .Must(subCategory => Enum.IsDefined(subCategory)).WithMessage(ResourceMessagesException.PRODUCT_SUB_CATEGORY_INVALID);

            RuleFor(x => x.SupplierOption)
                .Must(supplierOption => supplierOption == null ||
                Enum.IsDefined(typeof(SupplierOptionsEnum), supplierOption)).WithMessage(ResourceMessagesException.PRODUCT_SUPPLIER_OPTIONS_INVALID);

            RuleFor(x => x.SupplierPersonalizedName)
                .MaximumLength(200).WithMessage(ResourceMessagesException.PRODUCT_SUPPLIER_MAX_LENGH)
                .When(x => x.SupplierOption == null || x.SupplierOption == SupplierOptionsEnum.Indefinite)
                .WithMessage(ResourceMessagesException.PRODUCT_SUPPLIER_INVALID);
        }
    }
}