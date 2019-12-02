namespace ByteDev.PwnedPasswords
{
    /// <summary>
    /// Represents a response from the pwned password API.
    /// </summary>
    public class PwnedPasswordResponse
    {
        /// <summary>
        /// Whether the password has been pwned or not.
        /// </summary>
        public bool IsPwned { get; set; }

        /// <summary>
        /// How many times has the password been pwned.
        /// </summary>
        public long Count { get; set; }

        internal static PwnedPasswordResponse CreateNotPwned()
        {
            return new PwnedPasswordResponse
            {
                IsPwned = false,
                Count = 0
            };
        }

        internal static PwnedPasswordResponse CreatePwned(long numberOfTimes)
        {
            if (numberOfTimes < 1)
                return CreateNotPwned();

            return new PwnedPasswordResponse
            {
                IsPwned = true,
                Count = numberOfTimes
            };
        }
    }
}