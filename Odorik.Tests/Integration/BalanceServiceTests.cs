using System.Threading.Tasks;

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
        public async Task GetBalance_ReturnsPositiveNumber_Test()
        {
            var creditService = new CreditService(new FakeOdorikCredentials());

            var result = await creditService.GetBalanceAsync();

            Assert.IsTrue(result > 0);
        }
    }
}
