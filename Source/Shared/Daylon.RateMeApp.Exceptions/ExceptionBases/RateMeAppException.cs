namespace Daylon.RateMeApp.Exceptions.ExceptionBases
{
    public class RateMeAppException : SystemException
    {
        public RateMeAppException() { }

        public RateMeAppException(string message) : base(message) { }

        public RateMeAppException(string message, Exception innerException) : base(message, innerException) { }
    }
}