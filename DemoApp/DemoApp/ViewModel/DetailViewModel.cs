using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.ViewModel
{
    public class DetailViewModel : BaseViewModel
    {
        #region Properties

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }

        private string _wind;
        public string Wind
        {
            get { return _wind; }
            set { SetProperty(ref _wind, value); }
        }

        private string _weather;
        public string Weather
        {
            get { return _weather; }
            set { SetProperty(ref _weather, value); }
        }

        private string _temp;
        public string Temp
        {
            get { return _temp; }
            set { SetProperty(ref _temp, value); }
        }

        private string _pressure;
        public string Pressure
        {
            get { return _pressure; }
            set { SetProperty(ref _pressure, value); }
        }

        private string _humidity;
        public string Humidity
        {
            get { return _humidity; }
            set { SetProperty(ref _humidity, value); }
        }

        #endregion

        #region ctor
        public DetailViewModel()
        {
            if (App.weather_model != null)
            {
                Name = App.weather_model.name;
                Location = string.Format("{0},{1}", App.weather_model.coord.lat.ToString(), App.weather_model.coord.lon.ToString());
                Wind = string.Format("{0}", App.weather_model.wind.speed.ToString());
                Weather = App.weather_model.weather[0].description;
                Temp = string.Format("{0}, Max - {1}, Min - {2}",
                    App.weather_model.main.temp.ToString(),
                    App.weather_model.main.temp_max.ToString(),
                    App.weather_model.main.temp_min.ToString());
                Pressure = App.weather_model.main.pressure.ToString();
                Humidity = App.weather_model.main.humidity.ToString();
            }
        }

        #endregion
    }
}
