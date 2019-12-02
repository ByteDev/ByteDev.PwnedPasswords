using System.Threading;
using System.Threading.Tasks;

namespace ByteDev.PwnedPasswords
{
    /// <summary>
    /// Represents a client interface to the pwned Passwords API.
    /// </summary>
    public interface IPwnedPasswordsClient
    {
        /// <summary>
        /// Retrieves information as to whether <paramref name="password" /> has been pwned.
        /// </summary>
        /// <param name="password">Password to check.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<PwnedPasswordResponse> GetHasBeenPwnedAsync(string password);

        /// <summary>
        /// Retrieves information as to whether <paramref name="password" /> has been pwned.
        /// </summary>
        /// <param name="password">Password to check.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<PwnedPasswordResponse> GetHasBeenPwnedAsync(string password, CancellationToken cancellationToken);
    }
}