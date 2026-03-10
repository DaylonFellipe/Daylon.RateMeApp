using Daylon.RateMeApp.Communication.Responses.Error;

namespace Daylon.RateMeApp.Exceptions.ExceptionBases
{
    public class ErrorOnValidationException(List<string> validationErrors) : RateMeAppException
    {
        public List<string> ValidationErrorsMessages = validationErrors;
    }
}