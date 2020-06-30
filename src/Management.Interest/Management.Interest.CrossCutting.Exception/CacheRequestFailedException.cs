using Management.Interest.CrossCutting.Exception.Base;
using System.Net;

namespace Management.Interest.CrossCutting.Exception
{
    public class CacheRequestFailedException: ApiHttpCustomException
    {
        public CacheRequestFailedException(string message = "CacheRequestFailedException", HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
           : base(message)
        {
            this.ResponseCode = httpStatusCode;
        }
    }
}
