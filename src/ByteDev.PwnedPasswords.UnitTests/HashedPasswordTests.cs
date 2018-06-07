using System;
using NUnit.Framework;

namespace ByteDev.PwnedPasswords.UnitTests
{
    [TestFixture]
    public class HashedPasswordTests
    {
        private const string ClearText = "12345";
        private const string Sha1Text = "8CB2237D0679CA88DB6464EAC60DA96345513964";

        [Test]
        public void WhenTextIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => new HashedPassword(null));
        }

        [Test]
        public void WhenTextIsEmpty_ThenThrowException()
        {
            Assert.Throws<ArgumentException>(() => new HashedPassword(string.Empty));
        }

        [Test]
        public void WhenTextProvided_ThenSetProperties()
        {
            var sut = new HashedPassword(ClearText);

            Assert.That(sut.ClearPassword, Is.EqualTo(ClearText));
            Assert.That(sut.Hash, Is.EqualTo(Sha1Text));
            Assert.That(sut.HashPrefix, Is.EqualTo("8CB22"));
            Assert.That(sut.HashSuffix, Is.EqualTo("37D0679CA88DB6464EAC60DA96345513964"));
        }
    }
}