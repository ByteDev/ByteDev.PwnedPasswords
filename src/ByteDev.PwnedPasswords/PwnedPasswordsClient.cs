using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ByteDev.PwnedPasswords.Response;

namespace ByteDev.PwnedPasswords
{
    public class PwnedPasswordsClient
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<PwnedPasswordResponse> GetHasBeenPwnedAsync(HashedPassword hashedPassword)
        {
            if (hashedPassword == null)
                throw new ArgumentNullException(nameof(hashedPassword));

            var response = await HttpClient.GetAsync(UriFactory.GetHashPasswordUri(hashedPassword));

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

        private static string CreateUnhandledStatusCodeMessage(HttpResponseMessage response)
        {
            return $"Unhandled StatusCode: '{(int)response.StatusCode} {response.StatusCode}' returned.";
        }
    }
}