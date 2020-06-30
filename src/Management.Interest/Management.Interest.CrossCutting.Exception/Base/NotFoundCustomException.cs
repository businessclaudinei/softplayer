using System.Net;

namespace Management.Interest.CrossCutting.Exception.Base
{
    public class NotFoundCustomException : ApiHttpCustomException
    {
        public NotFoundCustomException(string message = "NotFoundCustomException")
            : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
