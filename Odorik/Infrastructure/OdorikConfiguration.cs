using System.Diagnostics;

namespace Odorik.Infrastructure
{
    public static class OdorikConfiguration
    {
        public static IOdorikCredentials Credentials { get; private set; }


        public static void SetCredentials(IOdorikCredentials credentials)
        {
            Credentials = credentials;
        }


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
