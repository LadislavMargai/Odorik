using System;
using Newtonsoft.Json;

using Odorik.Infrastructure;

namespace Odorik.Services
{
    public abstract class BaseService
    {
        protected readonly IOdorikCredentials Credentials;


        /// <summary>
        /// Constructor. If are not specified <paramref name="credentials"/>, they are retrieved from <see cref="OdorikConfiguration.Credentials" />. 
        /// </summary>
        /// <param name="credentials">Credentials.</param>
        protected BaseService(IOdorikCredentials credentials = null)
        {
            Credentials = credentials ?? OdorikConfiguration.Credentials;

            if (Credentials == null)
            {
                throw new ArgumentNullException(nameof(credentials), $"Credentials must be specified in {nameof(credentials)} parameter or in {nameof(OdorikConfiguration.Credentials)}");
            }
        }


        /// <summary>
        /// Deserialize <paramref name="resultString"/> to object specified by <typeparam name="T"></typeparam>
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="resultString">Result string to process.</param>
        /// <returns>Deserialized object.</returns>
        /// <exception cref="OdorikException">Throws when deserialization failed.</exception>
        protected T DeserializeResult<T>(string resultString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(resultString);
            }
            catch (JsonSerializationException)
            {
                throw new OdorikException(resultString);
            }
        }
    }
}
