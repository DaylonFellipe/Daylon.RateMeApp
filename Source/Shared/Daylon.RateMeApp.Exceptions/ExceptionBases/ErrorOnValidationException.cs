namespace Daylon.RateMeApp.Exceptions.ExceptionBases
{
    public class ErrorOnValidationException(List<string> validationErrors) : Exception
    {
        public List<string> ValidationErrorsMessages = validationErrors;
    }
}