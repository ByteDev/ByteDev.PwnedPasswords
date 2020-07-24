using System;
using ByteDev.PwnedPasswords.Response;
using NUnit.Framework;

namespace ByteDev.PwnedPasswords.UnitTests.Response
{
    [TestFixture]
    public class FiveCharOnlyResponseTests
    {
        private const string ValidContent =
            "E5D64B0E216796E834F52D61FD0B70332FC:2\n\r" +
            "D09CA3762AF61E59520943DC26494F8941B:5\n\r" +
            "37D0679CA88DB6464EAC60DA96345513964:3";

        [TestFixture]
        public class Constructor : FiveCharOnlyResponseTests
        {
            [Test]
            public void WhenContentIsNull_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new FiveCharOnlyResponse(null));
            }

            [Test]
            public void WhenContentIsEmpty_ThenThrowException()
            {
                Assert.Throws<ArgumentException>(() => _ = new FiveCharOnlyResponse(string.Empty));
            }

            [Test]
            public void WhenValidContent_ThenSetProperties()
            {
                var sut = new FiveCharOnlyResponse(ValidContent);

                Assert.That(sut.RawContent, Is.EqualTo(ValidContent));
                Assert.That(sut.RawContentLines.Length, Is.EqualTo(3));
            }
        }

        [TestFixture]
        public class GetCount : FiveCharOnlyResponseTests
        {
            private FiveCharOnlyResponse _sut;

            [SetUp]
            public void SetUp()
            {
                _sut = new FiveCharOnlyResponse(ValidContent);
            }

            [Test]
            public void WhenHashExists_AndResponseIsOneRecord_ThenReturnCount()
            {
                var sut = new FiveCharOnlyResponse("E5D64B0E216796E834F52D61FD0B70332FC:2");

                var result = sut.GetCount(new HashedPassword("1234567"));

                Assert.That(result, Is.EqualTo(2));
            }

            [Test]
            public void WhenHashExistsAtBeginning_ThenReturnCount()
            {
                var result = _sut.GetCount(new HashedPassword("1234567"));

                Assert.That(result, Is.EqualTo(2));
            }

            [Test]
            public void WhenHashExistsInMiddle_ThenReturnCount()
            {
                var result = _sut.GetCount(new HashedPassword("123456"));

                Assert.That(result, Is.EqualTo(5));
            }

            [Test]
            public void WhenHashExistsAtEnd_ThenReturnCount()
            {
                var result = _sut.GetCount(new HashedPassword("12345"));

                Assert.That(result, Is.EqualTo(3));
            }

            [Test]
            public void WhenHashDoesNotExist_ThenReturnZero()
            {
                var result = _sut.GetCount(new HashedPassword("Password1"));

                Assert.That(result, Is.EqualTo(0));
            }
        }
    }
}