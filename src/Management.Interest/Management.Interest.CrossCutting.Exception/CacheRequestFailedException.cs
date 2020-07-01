using Management.Interest.CrossCutting.Exception.Base;

namespace Management.Interest.CrossCutting.Exception
{
    public class CacheRequestFailedException: ApiHttpCustomException
    {
        public CacheRequestFailedException(string message = "CacheRequestFailedException")
           : base(message)
        {
        }
    }
}
