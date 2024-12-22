using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Exceptions
{
    [Serializable]
    public class UserNotAuthenticatedException : Exception
    {
        public UserNotAuthenticatedException() { }

        public UserNotAuthenticatedException(string message) : base(message) { }

        public UserNotAuthenticatedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
