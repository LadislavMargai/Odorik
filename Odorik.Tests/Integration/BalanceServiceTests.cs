using NUnit.Framework;

using Odorik.Services;

namespace Odorik.Tests.Integration
{
    /// <summary>
    /// Odorik credit service tests.<see cref="FakeOdorikCredentials"/> must be set.
    /// </summary>
    [TestFixture]
    public class BalanceServiceTests
    {
        [TestCase]
        public void GetBalance_ReturnsPositiveNumber_Test()
        {
            var creditService = new CreditService(new FakeOdorikCredentials());

            var result = creditService.GetBalance();

            Assert.IsTrue(result > 0);
        }
    }
}
