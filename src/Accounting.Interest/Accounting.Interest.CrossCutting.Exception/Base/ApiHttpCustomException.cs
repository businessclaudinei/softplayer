using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Accounting.Interest.CrossCutting.Exceptions.Base
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class ApiHttpCustomException : System.Exception
    {
        public HttpStatusCode ResponseCode { get; set; }

        public ApiHttpCustomException(string message = "ApiHttpCustomException", HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError, System.Exception innerException = null) 
            : base(message, innerException)
        {
            this.ResponseCode = httpStatusCode;
        }
    }
}
