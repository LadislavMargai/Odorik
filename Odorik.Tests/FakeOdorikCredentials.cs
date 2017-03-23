using System;

using Odorik.Infrastructure;

namespace Odorik.Tests
{
    internal class FakeOdorikCredentials : IOdorikCredentials
    {
        public string OdorikEndpoint => Environment.GetEnvironmentVariable("OdorikEndpoint");


        public string User => Environment.GetEnvironmentVariable("OdorikUser");


        public string Password => Environment.GetEnvironmentVariable("OdorikPassword");
    }
}
