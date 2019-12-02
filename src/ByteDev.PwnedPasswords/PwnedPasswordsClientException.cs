using System;
using System.Runtime.Serialization;

namespace ByteDev.PwnedPasswords
{
    /// <summary>
    /// Represents a problem when talking to the Pwned Passwords API.
    /// </summary>
    [Serializable]
    public class PwnedPasswordsClientException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.PwnedPasswords.PwnedPasswordsClientException" /> class.
        /// </summary>
        public PwnedPasswordsClientException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.PwnedPasswords.PwnedPasswordsClientException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PwnedPasswordsClientException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.PwnedPasswords.PwnedPasswordsClientException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>       
        public PwnedPasswordsClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.PwnedPasswords.PwnedPasswordsClientException" /> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        protected PwnedPasswordsClientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}