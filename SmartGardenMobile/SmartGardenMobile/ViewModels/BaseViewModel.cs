using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using SmartGardenMobile.Models;
using SmartGardenMobile.Services;

namespace SmartGardenMobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set
            {
                OnPropertyChanged(nameof(Title));
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
