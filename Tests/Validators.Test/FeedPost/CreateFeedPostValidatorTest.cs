using CommonTestUtilities.Requests.FeedPost;
using Daylon.RateMeApp.Application.UseCases.FeedPost.Validators;
using Daylon.RateMeApp.Exceptions;
using FluentAssertions;

namespace Validators.Test.FeedPost
{
    public class CreateFeedPostValidatorTest
    {
        [Fact]
        public void Success()
        {
            var validator = new CreateFeedPostValidator();

            var request = RequestCreateFeedPostJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Error_Product_Id_Empty()
        {
            var validator = new CreateFeedPostValidator();

            var request = RequestCreateFeedPostJsonBuilder.Build();
            request.ProductId = default;

            var result = validator.Validate(request);

            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle(ResourceMessagesException.PRODUCT_ID_EMPTY);
        }
    }
}