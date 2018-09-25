using DemoApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DemoApp.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {

        }

        #region BackCommand

        private Command backCommand;
        public Command BackCommand
        {
            get { return backCommand ?? (backCommand = new Command(() => ExecuteBackCommand())); }
        }

        private void ExecuteBackCommand()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        #endregion
    }
}
