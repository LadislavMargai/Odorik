using System.Threading.Tasks;

using Odorik.Infrastructure;

namespace Odorik.Services
{
    /// <summary>
    /// Defines contract with <see cref="CreditService"/>.
    /// </summary>
    public interface ICreditService
    {
        /// <summary>
        /// Gets actual balance.
        /// </summary>
        /// <returns>Actual account balance.</returns>
        /// <exception cref="OdorikException">Throws when Odorik.cz refuses to get actual account balance. See <see cref="OdorikException.MessageCode" /> for details.</exception>
        Task<double> GetBalanceAsync();
    }
}
