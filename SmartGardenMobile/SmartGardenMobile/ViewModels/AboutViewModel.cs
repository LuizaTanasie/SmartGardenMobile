using SmartGardenMobile.Models;
using SmartGardenMobile.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SmartGardenMobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        RestService _restService;
        public SmartPotModel measurement = new SmartPotModel();

        public decimal? Temperature
        {
            get { return measurement.Temperature; }
            set
            {
                measurement.Temperature = value;
                OnPropertyChanged(nameof(Temperature));
            }
        }

        public decimal? Humidity
        {
            get { return measurement.Humidity; }
            set
            {
                measurement.Humidity = value;
                OnPropertyChanged(nameof(Humidity));
            }
        }

        public decimal? SoilMoisture
        {
            get { return measurement.SoilMoisture; }
            set
            {
                measurement.SoilMoisture = value;
                OnPropertyChanged(nameof(SoilMoisture));
            }
        }

        public decimal? Light
        {
            get { return measurement.Light; }
            set
            {
                measurement.Light = value;
                OnPropertyChanged(nameof(Light));
            }
        }

        public bool? IsRaining
        {
            get { return measurement.IsRaining; }
            set
            {
                measurement.IsRaining = value;
                OnPropertyChanged(nameof(IsRaining));
            }
        }

        public AboutViewModel()
        {
            _restService = new RestService();
            Title = "Main";
            OnGetMeasurementButtonClicked = new Command(() =>Get());
        }

        public ICommand OnGetMeasurementButtonClicked { get; }

        public async void  Get()
        {
            var m =  await _restService.GetLastMeasurement(new Guid("B06C58EF-D364-47BB-BF21-6317872018E3"));
            Temperature = m?.Temperature;
            SoilMoisture = m?.SoilMoisture;
            Humidity = m?.Humidity;
            Light = m?.Light;
            IsRaining = m?.IsRaining;
        }
    }
}