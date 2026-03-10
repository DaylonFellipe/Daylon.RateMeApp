namespace Daylon.RateMeApp.Communication.Responses.Error
{
    public class ResponseErrorJson
    {
        public IList<string> Errors { get; set; }
        public ResponseErrorJson(string message) => Errors = [message];
        public ResponseErrorJson(IEnumerable<string> messages) => Errors = [.. messages];
    }
}