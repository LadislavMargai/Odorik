using System.Linq;

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
        public void GetSpeedDialList_ReturnsExactRecords_Test()
        {
            var speedDialService = new SpeedDialService(new FakeOdorikCredentials());

            var result = speedDialService.GetSpeedDialList();

            Assert.IsTrue(result.Any());
        }
    }
}
