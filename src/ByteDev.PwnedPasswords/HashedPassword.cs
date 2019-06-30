using System;
using ByteDev.PwnedPasswords.Hashing;

namespace ByteDev.PwnedPasswords
{
    internal class HashedPassword
    {
        public string ClearPassword { get; }

        public string Hash { get; }

        public string HashPrefix => Hash.Substring(0, 5);

        public string HashSuffix => Hash.Substring(5);

        public HashedPassword(string clearPassword)
        {
            if(string.IsNullOrEmpty(clearPassword))
                throw new ArgumentException("Password is null or empty.");

            ClearPassword = clearPassword;
            Hash = Sha1Hasher.Hash(clearPassword);
        }
    }
}