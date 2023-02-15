using AffiliateSite.WebApi.Infrastructure;
using FluentAssertions;

namespace AffiliateSite.UnitTests
{
    [TestFixture]
    public class CryptoTests
    {
        [Test]
        public void TestByCryptoDES()
        {
            var password = "abc123";
            var ciphertext = "APv4Up+DgB9glxWulAfiG5RvQ08uqtykckWHf+UkhewiaWgwUXaaC8Zl9Za5chikMA==";
            var actual = CryptoDES.VerifyHashedPassword(ciphertext, password);

            Assert.IsTrue(actual);
        }

        [Test]
        public void TestByCryptographyHelper() 
        {
            var plaintext = "N88AFF1736";
            var expect = "B8B87A858056E8CBC48A5A68BC5F8A";
            var actual = CryptographyHelper.Encrypt(plaintext);
            actual.Should().Be(expect);
        }
    }
}
