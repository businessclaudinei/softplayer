using System.Collections.Generic;
using System.Net;

namespace Accounting.Interest.CrossCutting.Exception.Base
{
    public class BadRequestCustomException : ApiHttpCustomException
    {
        public IEnumerable<ErrorModel> InvalidFields { get; set; }

        public BadRequestCustomException(IEnumerable<ErrorModel> errors, string message = "BadRequestCustomException")
            : base(message, HttpStatusCode.BadRequest)
        {
            this.InvalidFields = errors;
        }
    }
}
