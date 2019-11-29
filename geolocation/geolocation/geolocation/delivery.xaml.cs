using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace geolocation
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class delivery : ContentPage
    {
        Geocoder geoCoder;

        public delivery()
        {
            InitializeComponent();
            geoCoder = new Geocoder();
            var latlong = "";
            map.MapClicked += async (s, arg) =>
            {
                var x = arg.Position.Latitude;
                var y = arg.Position.Longitude;
                latlong = x + "," + y;
                if (!string.IsNullOrWhiteSpace(latlong))
                {
                    string[] coordinates = latlong.Split(',');
                    double? latitude = Convert.ToDouble(coordinates[0]);
                    double? longitude = Convert.ToDouble(coordinates[1]);

                    if (latitude != null && longitude != null)
                    {
                        Position position = new Position(latitude.Value, longitude.Value);
                        IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                        //Geocoder;
                        string address = possibleAddresses.FirstOrDefault();
                        reverseGeocodedOutputLabel.Text = address;
                    }
                }
            };
        }
        async void OnReverseGeocodeButtonClicked(object sender, EventArgs e)
        {
            var latlong2 = "16.43307340526658, 102.8255601788635";
            map.MapClicked += (s, arg) =>
           {
               var x = arg.Position.Latitude;
               var y = arg.Position.Longitude;
               latlong2 = x + "," + y;
           };
            if (!string.IsNullOrWhiteSpace(latlong2))
            {
                string[] coordinates = latlong2.Split(',');
                double? latitude = Convert.ToDouble(coordinates[0]);
                double? longitude = Convert.ToDouble(coordinates[1]);

                if (latitude != null && longitude != null)
                {
                    Position position = new Position(latitude.Value, longitude.Value);
                    IEnumerable<string> possibleAddresses = await geoCoder.GetAddressesForPositionAsync(position);
                    IEnumerable<Position> possibleAddresses2 = await geoCoder.GetPositionsForAddressAsync(possibleAddresses.FirstOrDefault());
                    //Geocoder;
                    string address = possibleAddresses.FirstOrDefault();
                    reverseGeocodedOutputLabel.Text = address;
                }
            }
        }
    }
}