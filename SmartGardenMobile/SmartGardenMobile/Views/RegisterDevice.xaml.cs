using SmartGardenMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace SmartGardenMobile.Views
{
    public partial class RegisterDevice : ContentPage
    {
		ZXingScannerPage scanPage;
		Button buttonScanDefaultOverlay;

		public RegisterDevice()
        {

            InitializeComponent();
			var viewModel = new RegisterDeviceViewModel();
			BindingContext = viewModel;

			buttonScanDefaultOverlay = new Button
			{
				Text = "Scan QR",
				AutomationId = "scanWithDefaultOverlay",
			};
			buttonScanDefaultOverlay.Clicked += async delegate
			{
				scanPage = new ZXingScannerPage();
				scanPage.OnScanResult += (result) =>
				{
					scanPage.IsScanning = false;

					Device.BeginInvokeOnMainThread(async () =>
					{
						await Navigation.PopAsync();
						var id = await viewModel.RegisterDevice(result.Text);
						if (id != null)
						{
							await Navigation.PushAsync(new HomePage());
						}
						else {
							await DisplayAlert("Error","The device cannot be found. Please try again.","Close");
						}
					});
				};

				await Navigation.PushAsync(scanPage);
			};
			var stack = new StackLayout();
			stack.Children.Add(new Label { Text = "Please scan the QR code on your device:" });
			stack.Children.Add(buttonScanDefaultOverlay);
			Content = stack;

		}
    }
}