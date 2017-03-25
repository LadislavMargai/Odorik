namespace Odorik.Infrastructure
{
    /// <summary>
    /// Contract defines credentials.
    /// </summary>
    public interface IOdorikCredentials
    {
        /// <summary>
        /// Odorik endpoint.
        /// </summary>
        string OdorikEndpoint { get; }


        /// <summary>
        /// User.
        /// </summary>
        string User { get; }


        /// <summary>
        /// Password.
        /// </summary>
        string Password { get; }
    }
}
