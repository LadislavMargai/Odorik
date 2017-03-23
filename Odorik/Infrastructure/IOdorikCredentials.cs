namespace Odorik.Infrastructure
{
    /// <summary>
    /// Contract defines credentials.
    /// </summary>
    public interface IOdorikCredentials
    {
        string OdorikEndpoint { get; }


        string User { get; }


        string Password { get; }
    }
}
