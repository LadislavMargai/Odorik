namespace Odorik.Infrastructure
{
    /// <summary>
    /// Default implementation for credentials retrieval.
    /// </summary>
    internal class DefaultOdorikCredentials : IOdorikCredentials
    {
        public string OdorikEndpoint { get; set; }


        public string User { get; set; }


        public string Password { get; set; }
    }
}
