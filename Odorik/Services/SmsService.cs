using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

using Odorik.Infrastructure;
using Odorik.Models.Sms;

namespace Odorik.Services
{
    /// <summary>
    /// SMS service.
    /// </summary>
    public class SMSService : BaseService, ISMSService
    {
        #region "API resources"

        private const string SendSMS = "sms";
        private const string SentSMS = "sms.json";
        private const string AllowedSenders = "sms/allowed_sender";
        private const string SmsSuccessfullySendFlag = "successfully_sent";

        #endregion


        #region "Public methods"

        /// <summary>
        /// Constructor. If are not specified <paramref name="credentials"/>, they are retrieved from <see cref="OdorikConfiguration.Credentials" />. 
        /// </summary>
        /// <param name="credentials">Credentials.</param>
        public SMSService(IOdorikCredentials credentials = null) : base(credentials) { }
        

        /// <summary>
        /// Gets allowed senders for <see cref="NewSMS.Sender"/>.
        /// </summary>
        /// <returns>Collection of allowed senders.</returns>
        public async Task<IEnumerable<string>> GetAllowedSendersAsync()
        {
            using (var client = new OdorikClient(Credentials))
            {
                var result = await client.GetAsync(null, AllowedSenders);

                return result.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
        }


        /// <summary>
        /// Sends a new SMS message.
        /// </summary>
        /// <param name="sender">Sender must be one of the allowed senders from <see cref="GetAllowedSendersAsync"/></param>
        /// <param name="recipient">Recipient number in format 00xxxx, for example 00420 123 456 789</param>
        /// <param name="message">Text of message</param>
        /// <returns>Returns remaining credit.</returns>
        /// <exception cref="OdorikException">Throws when Odorik.cz refuses to send SMS. See <see cref="OdorikException.MessageCode" /> for details.</exception>
        public async Task<double> SendSmsAsync(string sender, string recipient, string message)
        {
            var sms = new NewSMS
            {
                Message = message,
                Recipient = recipient,
                Sender = sender
            };

            using (var client = new OdorikClient(Credentials))
            {
                var result = await client.PostAsync(sms, SendSMS);

                if (result.Contains(SmsSuccessfullySendFlag))
                {
                    var value = result.Replace(SmsSuccessfullySendFlag, string.Empty);
                    return double.Parse(value, NumberStyles.Float, CultureInfo.InvariantCulture);
                }

                throw new OdorikException(result);
            }
        }


        /// <summary>
        /// Gets <see cref="SentSMS"/>s limited by <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter"><see cref="SMSFilter"/> contains From and To limitation</param>
        /// <returns>Collection of <see cref="SentSMS"/></returns>
        /// <exception cref="OdorikException">Throws when Odorik.cz refuses to get SMSs. See <see cref="OdorikException.MessageCode" /> for details.</exception>
        public async Task<IEnumerable<SentSMS>> GetSentSMSsAsync(SMSFilter filter)
        {
            using (var client = new OdorikClient(Credentials))
            {
                var result = await client.GetAsync(filter, SentSMS);

                return DeserializeResult<IEnumerable<SentSMS>>(result);
            }
        }

        #endregion
    }
}