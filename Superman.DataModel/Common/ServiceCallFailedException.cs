using System;

namespace Superman.DataModel.Common
{
    public class ServiceCallFailedException : Exception
    {
        public ServiceCallFailedException() : base() { }
        public ServiceCallFailedException(string message) : base(message) { }

        public ServiceCallFailedException(string message, Exception innerException)
            : base(message, innerException)
        { }

    }
}
