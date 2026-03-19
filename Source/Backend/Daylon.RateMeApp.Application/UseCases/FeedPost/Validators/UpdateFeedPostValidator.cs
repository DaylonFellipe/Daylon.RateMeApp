using Daylon.RateMeApp.Communication.Requests.FeedPost;
using FluentValidation;

namespace Daylon.RateMeApp.Application.UseCases.FeedPost.Validators
{
    public class UpdateFeedPostValidator : AbstractValidator<RequestUpdateFeedPostJson>
    {
        public UpdateFeedPostValidator()
        {
            RuleFor(x => x.Id)
                .Must(id => id != Guid.Empty).WithMessage("The Id field must be a valid GUID.")
                .NotEmpty().WithMessage("The Id field is required.");

            RuleFor(x => x.ProductId)
                .Must(id => id != Guid.Empty).WithMessage("The ProductId field must be a valid GUID.");

            RuleFor(x => x.IsFavorite)
                .Must(isFavorite => isFavorite == null || isFavorite == true || isFavorite == false)
                .WithMessage("The IsFavorite field must be a boolean value (true or false) or null.");
        }
    }
}