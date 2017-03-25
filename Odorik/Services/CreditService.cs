using System.Threading.Tasks;
using Odorik.Infrastructure;

namespace Odorik.Services
{
    /// <summary>
    /// Credit service.
    /// </summary>
    public class CreditService : BaseService, ICreditService
    {
        #region "API resources"

        private const string Credit = "balance";

        #endregion


        #region "Public methods"

        /// <summary>
        /// Constructor. If are not specified <paramref name="credentials"/>, they are retrieved from <see cref="OdorikConfiguration.Credentials" />. 
        /// </summary>
        /// <param name="credentials">Credentials.</param>
        public CreditService(IOdorikCredentials credentials = null) : base(credentials) { }


        /// <summary>
        /// Gets actual balance.
        /// </summary>
        /// <returns>Actual account balance.</returns>
        /// <exception cref="OdorikException">Throws when Odorik.cz refuses to get actual account balance. See <see cref="OdorikException.MessageCode" /> for details.</exception>
        public async Task<double> GetBalanceAsync()
        {
            using (var client = new OdorikClient(Credentials))
            {
                var result = await client.GetAsync(null, Credit);

                return DeserializeResult<double>(result);
            }
        }

        #endregion
    }
}
