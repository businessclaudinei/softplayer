using Newtonsoft.Json;
using System.Net;

namespace Accounting.Interest.CrossCutting.Configuration.ExceptionModels
{
    public sealed class DefaultExceptionResponse
    {
        public DefaultExceptionResponse(string message, HttpStatusCode httpStatusCode)
        {
            Notification = new NotificationObject
            {
                HttpStatusCode = httpStatusCode,
                Message = message
            };
        }

        public DefaultExceptionResponse(System.Exception exception, string message, HttpStatusCode httpStatusCode)
        {
            Notification = new NotificationObject
            {
                Details = exception,
                HttpStatusCode = httpStatusCode,
                Message = message
            };
        }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("notification")]
        public NotificationObject Notification { get; set; }

        public class NotificationObject
        {
            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("httpStatusCode")]
            public HttpStatusCode HttpStatusCode { get; set; }

            [JsonProperty("details")]
            public System.Exception Details { get; set; }
        }
    }
}
