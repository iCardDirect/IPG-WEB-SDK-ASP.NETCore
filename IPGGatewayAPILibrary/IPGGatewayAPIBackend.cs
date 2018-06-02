using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IPGGatewayAPILibrary
{
    /// <summary>
    /// Backend functionality
    /// </summary>
    public abstract class IPGGatewayAPIBackend : IPGGatewayAPI
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public IPGGatewayAPIBackend(string data) : base(data) { }
        /// <summary>
        /// Get data from server
        /// </summary>
        /// <returns></returns>
        protected async Task<string> GetRawResult()
        {
            var newProperty = !_properties.ContainsKey("Signature");
            string resultContent;
            if (newProperty)
                _properties["Signature"] = Convert.ToBase64String(Sign());
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(DefaultURL);
                HttpResponseMessage result = await client.PostAsync(DefaultURL, new FormUrlEncodedContent(_properties));
                resultContent = await result.Content.ReadAsStringAsync();
            }
            if (newProperty)
                _properties.Remove("Signature");
            return resultContent;
        }
        /// <summary>
        /// Send request
        /// </summary>
        /// <returns></returns>
        protected async Task<string> SendRequestAsync()
        {
            string data = await GetRawResult();
            return data;
        }

        /// <summary>
        /// Get data without formating
        /// </summary>
        /// <returns></returns>
        public string GetData()
        {
            var a = SendRequestAsync();
            return a.Result;
        }
        /// <summary>
        /// Get XML
        /// </summary>
        /// <returns></returns>
        public string GetXML()
        {
            _properties["OutputFormat"] = "xml";
            var data = SendRequestAsync();
            _properties.Remove("OutputFormat");
            return data.Result;
        }
        /// <summary>
        /// Get JSON
        /// </summary>
        /// <returns></returns>
        public string GetJSON()
        {
            _properties["OutputFormat"] = "json";
            var data = SendRequestAsync();
            _properties.Remove("OutputFormat");
            return data.Result;
        }
    }
}
