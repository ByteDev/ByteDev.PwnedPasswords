using System;

namespace ByteDev.PwnedPasswords
{
    internal class UriFactory
    {
        public static Uri GetHashPasswordUri(HashedPassword hashedPassword)
        {
            return new Uri("https://api.pwnedpasswords.com/range/" + hashedPassword.HashPrefix);
        }
    }
}