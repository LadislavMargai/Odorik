using NUnit.Framework;

using Odorik.Services;

namespace Odorik.Tests.Integration
{
    /// <summary>
    /// Odorik balance service tests.<see cref="FakeOdorikCredentials"/> must be set.
    /// </summary>
    [TestFixture]
    public class BalanceServiceTests
    {
        [TestCase]
        public void GetBalance_ReturnsPositiveNumber_Test()
        {
            var balanceService = new BalanceService(new FakeOdorikCredentials());

            var result = balanceService.GetBalance();

            Assert.IsTrue(result > 0);
        }
    }
}
