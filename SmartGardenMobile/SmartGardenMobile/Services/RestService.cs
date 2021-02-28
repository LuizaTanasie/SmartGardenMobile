using Newtonsoft.Json;
using SmartGardenMobile.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartGardenMobile.Services
{
    public class RestService
    {
        HttpClient _client;
        private readonly string API = "https://sg-func.azurewebsites.net/api/";

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
                var response = await _client.GetAsync(API+ "/GetLatestMeasurement?DeviceId=" + deviceId);
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
        public async Task<Guid?> RegisterDevice(string serialNumber)
        {
            try
            {
                var response = await _client.GetAsync(API + "/RegisterDevice?SerialNumber=" + serialNumber);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var id = JsonConvert.DeserializeObject<string>(content);

                    if (Guid.TryParse(id, out _))
                    {
                        return Guid.Parse(id);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
            return null;
        }

    }
}
