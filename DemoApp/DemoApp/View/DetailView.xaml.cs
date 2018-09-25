using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace DemoApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {
        public DetailView()
        {
            InitializeComponent();

            var position = new Position(App.weather_model.coord.lat, App.weather_model.coord.lon); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "custom pin",
                Address = "custom detail info"
            };
            MyMap.Pins.Add(pin);

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1)));
        }
    }
}