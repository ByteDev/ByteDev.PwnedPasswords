using System;
using System.Runtime.Serialization;

namespace ByteDev.PwnedPasswords
{
    [Serializable]
    public class PwnedPasswordsClientException : Exception
    {
        public PwnedPasswordsClientException()
        {
        }

        public PwnedPasswordsClientException(string message) : base(message)
        {
        }

        public PwnedPasswordsClientException(string message, Exception inner) : base(message, inner)
        {
        }

        protected PwnedPasswordsClientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}