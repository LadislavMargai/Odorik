using System.Collections.Generic;
using System.Threading.Tasks;

using Odorik.Infrastructure;
using Odorik.Models.Sms;

namespace Odorik.Services
{
    /// <summary>
    /// Defines contract with <see cref="SMSService"/>.
    /// </summary>
    public interface ISMSService
    {
        /// <summary>
        /// Gets allowed senders for <see cref="NewSMS.Sender"/>.
        /// </summary>
        /// <returns>Collection of allowed senders.</returns>
        Task<IEnumerable<string>> GetAllowedSendersAsync();


        /// <summary>
        /// Sends a new SMS message.
        /// </summary>
        /// <param name="sender">Sender must be one of the allowed senders from <see cref="GetAllowedSendersAsync"/></param>
        /// <param name="recipient">Recipient number in format 00xxxx, for example 00420 123 456 789</param>
        /// <param name="message">Text of message</param>
        /// <returns>Returns remaining credit.</returns>
        /// <exception cref="OdorikException">Throws when Odorik.cz refuses to send SMS. See <see cref="OdorikException.MessageCode" /> for details.</exception>
        Task<double> SendSmsAsync(string sender, string recipient, string message);


        /// <summary>
        /// Gets <see cref="SentSMS"/>s limited by <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter"><see cref="SMSFilter"/> contains From and To limitation</param>
        /// <returns>Collection of <see cref="SentSMS"/></returns>
        /// <exception cref="OdorikException">Throws when Odorik.cz refuses to get SMSs. See <see cref="OdorikException.MessageCode" /> for details.</exception>
        Task<IEnumerable<SentSMS>> GetSentSMSsAsync(SMSFilter filter);
    }
}