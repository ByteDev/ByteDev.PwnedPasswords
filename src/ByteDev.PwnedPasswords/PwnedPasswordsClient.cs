using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ByteDev.PwnedPasswords.Response;

namespace ByteDev.PwnedPasswords
{
    public class PwnedPasswordsClient : IPwnedPasswordsClient
    {
        private readonly HttpClient _httpClient;

        public PwnedPasswordsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PwnedPasswordResponse> GetHasBeenPwnedAsync(string password)
        {
            return await GetHasBeenPwnedAsync(password, default(CancellationToken));
        }

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
                throw new PwnedPasswordsClientException("Error occured while calling the PwnedPasswords API.", ex);
            }
        }

        private static string CreateUnhandledStatusCodeMessage(HttpResponseMessage response)
        {
            return $"Unhandled StatusCode: '{(int)response.StatusCode} {response.StatusCode}' returned.";
        }
    }
}