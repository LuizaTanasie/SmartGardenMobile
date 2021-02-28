using SmartGardenMobile.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SmartGardenMobile.ViewModels
{
    public class RegisterDeviceViewModel : BaseViewModel
    {
        RestService _restService;

        public RegisterDeviceViewModel()
        {
            _restService = new RestService();
            Title = "Register device";
        }

        public async Task<Guid?> RegisterDevice(string serialNumber)
        {
            var result = await _restService.RegisterDevice(serialNumber);
            if (result != null)
            {
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "deviceId.txt");
                File.WriteAllText(fileName, result.ToString());
            }

            return result;
        }
    }
}
