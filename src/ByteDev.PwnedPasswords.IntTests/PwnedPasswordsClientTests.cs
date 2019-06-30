using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ByteDev.PwnedPasswords.IntTests
{
    [TestFixture]
    public class PwnedPasswordsClientTests
    {
        private const string PwnedPassword = "12345";
        private const long PwnedPasswordCount = 2088998;

        private const string NotPwnedPassword = "fytfyfytftyfyfy76bg6b87bj";

        private PwnedPasswordsClient _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new PwnedPasswordsClient(new HttpClient());
        }

        [TestFixture]
        public class GetHasBeenPwnedAsync : PwnedPasswordsClientTests
        {
            [Test]
            public async Task WhenSendingHashPrefix_AndPwned_ThenReturnResponse()
            {
                var result = await _sut.GetHasBeenPwnedAsync(PwnedPassword);

                Assert.That(result.IsPwned, Is.True);
                Assert.That(result.Count, Is.GreaterThanOrEqualTo(PwnedPasswordCount));
            }

            [Test]
            public async Task WhenSendingHashPrefix_AndNotPwned_ThenReturnResponse()
            {
                var result = await _sut.GetHasBeenPwnedAsync(NotPwnedPassword);

                Assert.That(result.IsPwned, Is.False);
                Assert.That(result.Count, Is.EqualTo(0));
            }
        }
    }
}