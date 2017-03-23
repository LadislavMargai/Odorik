using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Odorik.Infrastructure
{
    internal class OdorikClient : IDisposable
    {
        #region "Variables & fields"

        private readonly HttpClient _client;
        private readonly string _authToken;

        #endregion


        #region "Public methods"

        /// <summary>
        /// Constructor. <paramref name="credentials"/> are required. 
        /// </summary>
        /// <param name="credentials">Credentials.</param>
        /// <exception cref="ArgumentNullException">Throws exception when credentials are null.</exception>
        public OdorikClient(IOdorikCredentials credentials)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException(nameof(credentials));
            }
            _client = new HttpClient { BaseAddress = new Uri(credentials.OdorikEndpoint) };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _authToken = $"?user={credentials.User}&password={credentials.Password}";
        }


        /// <summary>
        /// Performs POST request against Odorik.cz server.
        /// </summary>
        /// <param name="obj">Object to be sent.</param>
        /// <param name="identifier">Api resource identifier.</param>
        /// <returns>String response.</returns>
        /// <exception cref="WebException">Throws exception when communication failed.</exception>
        public string Post(object obj, string identifier)
        {
            var response = _client.PostAsync(AppendObjectInUrl(identifier, obj), new StringContent(string.Empty)).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            throw new WebException($"Communication with remote server failed. Status code: {response.StatusCode}");
        }


        /// <summary>
        /// Performs GET request against Odorik.cz server.
        /// </summary>
        /// <param name="obj">Object to be passed. e.g. filters, etc...</param>
        /// <param name="identifier">Api resource identifier.</param>
        /// <returns>String response.</returns>
        /// <exception cref="WebException">Throws exception when communication failed.</exception>
        public string Get(object obj, string identifier)
        {
            var response = _client.GetAsync(AppendObjectInUrl(identifier, obj)).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            throw new WebException($"Communication with remote server failed. Status code: {response.StatusCode}");
        }


        /// <summary>
        /// Dispose.
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
        }

        #endregion


        #region "Private methods"

        private string AppendObjectInUrl(string identifier, object obj = null)
        {
            var result = new StringBuilder();

            result.Append(identifier);
            result.Append(_authToken);

            if (obj != null)
            {
                // Get all properties via reflection
                foreach (var type in obj.GetType().GetRuntimeProperties())
                {
                    var tuple = GetNameValueOfProperty(type, obj);

                    result.Append($"&{tuple.Item1}={tuple.Item2}");
                }
            }

            return result.ToString();
        }


        private static Tuple<string, string> GetNameValueOfProperty(PropertyInfo property, object obj)
        {
            string name, value;

            if (property.PropertyType == typeof(DateTime))
            {
                // Special case for datetime format
                name = property.Name.ToLower();
                value = ((DateTime)property.GetValue(obj)).ToString("s", CultureInfo.InvariantCulture);
            }
            else
            {
                name = property.Name.ToLower();
                value = property.GetValue(obj).ToString();
            }

            return new Tuple<string, string>(name, value);
        }

        #endregion
    }
}
