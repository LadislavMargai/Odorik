using System;

namespace Odorik.Models.Sms
{
    /// <summary>
    /// Represents filter for getting SMSs.
    /// </summary>
    public class SMSFilter
    {
        public DateTime From { get; set; }


        public DateTime To { get; set; }
    }
}
