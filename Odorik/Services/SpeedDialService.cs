using System.Collections.Generic;
using System.Threading.Tasks;

using Odorik.Infrastructure;
using Odorik.Models.SpeedDial;

namespace Odorik.Services
{
    /// <summary>
    /// Speeddial service.
    /// </summary>
    public class SpeedDialService : BaseService, ISpeedDialService
    {
        #region "API resources"

        private const string SpeedDial = "speed_dials.json";

        #endregion


        #region "Public methods"

        /// <summary>
        /// Constructor. If are not specified <paramref name="credentials"/>, they are retrieved from <see cref="OdorikConfiguration.Credentials" />. 
        /// </summary>
        /// <param name="credentials">Credentials.</param>
        public SpeedDialService(IOdorikCredentials credentials = null) : base(credentials) { }


        /// <summary>
        /// Gets all <see cref="SpeedDial"/>s.
        /// </summary>
        /// <returns>Collection of <see cref="SpeedDial"/></returns>
        /// <exception cref="OdorikException">Throws when Odorik.cz refuses to get SpeedDials. See <see cref="OdorikException.MessageCode" /> for details.</exception>
        public async Task<IEnumerable<SpeedDial>> GetSpeedDialsAsync()
        {
            using (var client = new OdorikClient(Credentials))
            {
                var result = await client.GetAsync(null, SpeedDial);

                return DeserializeResult<IEnumerable<SpeedDial>>(result);
            }
        }

        #endregion
    }
}
