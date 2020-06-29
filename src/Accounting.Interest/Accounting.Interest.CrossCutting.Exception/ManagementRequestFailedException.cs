using Accounting.Interest.CrossCutting.Exception.Base;
using System.Net;

namespace Accounting.Interest.CrossCutting.Exception
{
    public class ManagementRequestFailedException : ApiHttpCustomException
    {
        public ManagementRequestFailedException(string message = "ManagementRequestFailedException", HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError)
            : base(message, httpStatusCode)
        {
        }
    }
}
