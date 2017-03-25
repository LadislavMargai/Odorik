namespace Odorik.Infrastructure
{
    /// <summary>
    /// Global Odorik configuration.
    /// </summary>
    public static class OdorikConfiguration
    {
        /// <summary>
        /// Gets Odorik credentials.
        /// </summary>
        public static IOdorikCredentials Credentials { get; private set; }


        /// <summary>
        /// Sets Odorik credentials.
        /// </summary>
        /// <param name="credentials">Custom credentials - <see cref="IOdorikCredentials"/> implementation</param>
        public static void SetCredentials(IOdorikCredentials credentials)
        {
            Credentials = credentials;
        }


        /// <summary>
        /// Sets Odorik credentials.
        /// </summary>
        /// <param name="odorikEndpoint">Odorik endpoint</param>
        /// <param name="user">User</param>
        /// <param name="password">Password</param>
        public static void SetCredentials(string odorikEndpoint, string user, string password)
        {
            Credentials = new DefaultOdorikCredentials
            {
                OdorikEndpoint = odorikEndpoint,
                User = user,
                Password = password
            };
        }
    }
}
