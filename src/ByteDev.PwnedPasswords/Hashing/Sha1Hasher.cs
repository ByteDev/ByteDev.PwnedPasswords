using System.Security.Cryptography;
using System.Text;

namespace ByteDev.PwnedPasswords.Hashing
{
    internal class Sha1Hasher
    {
        public static string Hash(string text)
        {
            using (var sha1 = new SHA1Managed())
            {
                byte[] hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));

                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));      // "x2" lowercase, "X2" uppercase
                }

                return sb.ToString();
            }
        }
    }
}