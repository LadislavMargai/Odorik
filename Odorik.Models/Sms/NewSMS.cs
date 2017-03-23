namespace Odorik.Models.Sms
{
    /// <summary>
    /// Represents new SMS for sending.
    /// </summary>
    public class NewSMS
    {
        public string Recipient { get; set; }


        public string Message { get; set; }


        public string Sender { get; set; }
    }
}
