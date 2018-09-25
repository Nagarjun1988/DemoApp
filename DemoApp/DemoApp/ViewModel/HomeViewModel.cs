using Acr.UserDialogs;
using DemoApp.Model;
using DemoApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace DemoApp.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        #region Properties

        private string _zipcode;
        public string Zipcode
        {
            get { return _zipcode; }
            set { SetProperty(ref _zipcode, value); }
        }
        #endregion

        #region ctor
        public HomeViewModel()
        {

        }

        #endregion

        #region Get Weather Data
        private Command _getWeatherCommand;
        public Command GetWeatherCommand
        {
            get { return _getWeatherCommand ?? (_getWeatherCommand = new Command(() => ExecuteGetWeatherCommand())); }
        }

        private async void ExecuteGetWeatherCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Zipcode) || string.IsNullOrWhiteSpace(Zipcode))
                {
                    UserDialogs.Instance.Alert("Please Enter Zipcode!");
                    return;
                }
                else
                {
                    UserDialogs.Instance.ShowLoading();

                    string url = "https://samples.openweathermap.org/data/2.5/weather?zip=" + Zipcode + ",us&appid=b6907d289e10d714a6e88b30761fae22";

                    Rest_Response rest_result = await WebService.WebService.GetRestData(url);
                    if (rest_result != null)
                    {
                        if (rest_result.status_code == 200)
                        {
                            App.weather_model = JsonConvert.DeserializeObject<WeatherDetail>(rest_result.response_body);

                            await App.Current.MainPage.Navigation.PushAsync(new DetailView());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }
        #endregion
    }
}
