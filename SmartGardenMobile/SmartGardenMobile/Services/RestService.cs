using Newtonsoft.Json;
using SmartGardenMobile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            _client = new HttpClient(httpClientHandler);
        }

        public async Task<SmartPotModel> GetLastMeasurement(Guid deviceId)
        {
            SmartPotModel measurement = null;
            try
            {
                var response = await _client.GetAsync("https://192.168.0.63:8000/api/SmartPot/GetLastMeasurement?deviceId=" + deviceId);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    measurement = JsonConvert.DeserializeObject<SmartPotModel>(content);
                }
            }
            catch (Exception ex)
            {
              //  Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return measurement;
        }
    }
}
