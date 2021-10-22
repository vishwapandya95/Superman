using System;
using System.Collections.Generic;
using System.Text;

namespace Superman.DataModel.Common
{
    public class UnauthorisedException : Exception
    {
        public UnauthorisedException() : base() { }
        public UnauthorisedException(string message) : base(message) { }

        public UnauthorisedException(string message, Exception innerException)
            : base(message, innerException)
        { }

    }
}
