using Accounting.Interest.CrossCutting.Exception.Base;

namespace Accounting.Interest.CrossCutting.Exception
{
    public class CacheRequestFailedException : ApiHttpCustomException
    {
        public CacheRequestFailedException(string message = "CacheRequestFailedException")
           : base(message)
        {
        }
    }
}
