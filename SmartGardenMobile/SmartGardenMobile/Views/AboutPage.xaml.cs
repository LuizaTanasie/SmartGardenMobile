using SmartGardenMobile.Models;
using SmartGardenMobile.Services;
using SmartGardenMobile.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartGardenMobile.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutViewModel();

        }


    }
}