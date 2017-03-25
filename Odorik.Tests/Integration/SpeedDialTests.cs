using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

using Odorik.Services;

namespace Odorik.Tests.Integration
{
    /// <summary>
    /// Odorik SpeedDial tests.<see cref="FakeOdorikCredentials"/> must be set.
    /// </summary>
    [TestFixture]
    public class SpeedDialTests
    {
        [TestCase]
        public async Task GetSpeedDialList_ReturnsExactRecords_Test()
        {
            var speedDialService = new SpeedDialService(new FakeOdorikCredentials());

            var result = await speedDialService.GetSpeedDialsAsync();

            Assert.IsTrue(result.Any());
        }
    }
}
