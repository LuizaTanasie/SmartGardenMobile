using SmartGardenMobile.Models;
using SmartGardenMobile.Services;
using SmartGardenMobile.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            var viewModel = new HomeViewModel();
            BindingContext = viewModel;
            viewModel.GetLastMeasurement();
        }
    }
}