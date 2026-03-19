using Daylon.RateMeApp.Communication.Requests.FeedPost;
using Daylon.RateMeApp.Exceptions;
using FluentValidation;

namespace Daylon.RateMeApp.Application.UseCases.FeedPost.Validators
{
    public class CreateFeedPostValidator : AbstractValidator<RequestCreateFeedPostJson>
    {
        public CreateFeedPostValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage(ResourceMessagesException.POST_PRODUCT_ID_EMPTY);

            RuleFor(x => x.IsFavorite)
                .NotNull().WithMessage(ResourceMessagesException.POST_FAVORITE_EMPTY);
        }
    }
}