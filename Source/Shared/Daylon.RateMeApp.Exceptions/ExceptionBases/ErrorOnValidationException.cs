namespace Daylon.RateMeApp.Exceptions.ExceptionBases
{
    public class ErrorOnValidationException(IList<string> errorMessages) : RateMeAppException
    {
        public IList<string> ErrorsMessages { get; } = errorMessages;
    }
}