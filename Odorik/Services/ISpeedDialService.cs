using System.Collections.Generic;

using Odorik.Infrastructure;
using Odorik.Models.SpeedDial;

namespace Odorik.Services
{
    /// <summary>
    /// Defines contract with <see cref="SpeedDialService"/>.
    /// </summary>
    public interface ISpeedDialService
    {
        /// <summary>
        /// Gets all <see cref="SpeedDial"/>s.
        /// </summary>
        /// <returns>Collection of <see cref="SpeedDial"/></returns>
        /// <exception cref="OdorikException">Throws when Odorik.cz refuses to get SpeedDials. See <see cref="OdorikException.MessageCode" /> for details.</exception>
        IEnumerable<SpeedDial> GetSpeedDials();
    }
}
