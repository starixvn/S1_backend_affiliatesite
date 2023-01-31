using AffiliateSite.WebApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffiliateSite.UnitTests
{
    [TestFixture]
    public class CryptoTests
    {
        [Test]
        public void Test1()
        {
            var crypto = new Crypto();
            var password = "abc123";

            var actual = crypto.VerifyHashedPassword(crypto.HashPassword(password), password);

            Assert.IsTrue(actual);
        }
    }
}
