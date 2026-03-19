using Daylon.RateMeApp.Exceptions.ExceptionBases;
using FluentValidation;

namespace Daylon.RateMeApp.Application.Helpers
{
    public class ApplicationHelper
    {
        public async Task ValidateRequestAsync<T>(T request, AbstractValidator<T> validator)
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