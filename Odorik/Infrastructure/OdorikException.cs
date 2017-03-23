using System;

namespace Odorik.Infrastructure
{
    /// <summary>
    /// Exception using message codes from Odorik.cz.
    /// </summary>
    public class OdorikException : Exception
    {
        /// <summary>
        /// Represents error code.
        /// Deails of could be found at https://www.odorik.cz/w/api/.
        /// </summary>
        public string MessageCode { get; private set; }


        /// <summary>
        /// Constructor. Sets <see cref="MessageCode"/>.
        /// </summary>
        /// <param name="message">Message code</param>
        public OdorikException(string message) : base($"[Odorik.cz error]: {message}")
        {
            MessageCode = message;
        }
    }
}
