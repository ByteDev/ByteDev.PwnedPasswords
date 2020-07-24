using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ByteDev.PwnedPasswords.Response;

namespace ByteDev.PwnedPasswords
{
    /// <summary>
    /// Represents a client to the pwned passwords API.
    /// </summary>
    public class PwnedPasswordsClient : IPwnedPasswordsClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ByteDev.PwnedPasswords.PwnedPasswordsClient" /> class.
        /// </summary>
        /// <param name="httpClient">HttpClient to use in all calls to the API.</param>
        public PwnedPasswordsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves information as to whether <paramref name="password" /> has been pwned.
        /// </summary>
        /// <param name="password">Password to check.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="password" />Password is null or empty.</exception>
        /// <exception cref="T:ByteDev.PwnedPasswords.PwnedPasswordsClientException">Error occured while calling the pwned passwords API.</exception>
        public async Task<PwnedPasswordResponse> GetHasBeenPwnedAsync(string password)
        {
            return await GetHasBeenPwnedAsync(password, default);
        }

        /// <summary>
        /// Retrieves information as to whether <paramref name="password" /> has been pwned.
        /// </summary>
        /// <param name="password">Password to check.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="T:System.ArgumentException"><paramref name="password" />Password is null or empty.</exception>
        /// <exception cref="T:ByteDev.PwnedPasswords.PwnedPasswordsClientException">Error occured while calling the pwned passwords API.</exception>
        public async Task<PwnedPasswordResponse> GetHasBeenPwnedAsync(string password, CancellationToken cancellationToken)
        {
            var hashedPassword = new HashedPassword(password);

            try
            {
                var response = await _httpClient.GetAsync(UriFactory.GetHashPasswordUri(hashedPassword), cancellationToken);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var body = await response.Content.ReadAsStringAsync();

                    var fiveCharResponse = new FiveCharOnlyResponse(body);

                    return PwnedPasswordResponse.CreatePwned(fiveCharResponse.GetCount(hashedPassword));
                }

                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return PwnedPasswordResponse.CreateNotPwned();
                }

                throw new PwnedPasswordsClientException(CreateUnhandledStatusCodeMessage(response));
            }
            catch (Exception ex)
            {
                throw new PwnedPasswordsClientException("Error occured while calling the pwned passwords API.", ex);
            }
        }

        private static string CreateUnhandledStatusCodeMessage(HttpResponseMessage response)
        {
            return $"Unhandled StatusCode: '{(int)response.StatusCode} {response.StatusCode}' returned.";
        }
    }
}