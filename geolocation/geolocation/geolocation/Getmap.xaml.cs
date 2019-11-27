using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.GoogleMaps;
//using Android.Gms.Maps;
//using Android.Gms.Maps.Model;
using System.Diagnostics;

namespace geolocation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Getmap : ContentPage
    {
        public Getmap()
        {
            //Map map = new Map();
            InitializeComponent();
            //var map = new Xamarin.Forms.Maps.Map(Xamarin.Forms.GoogleMaps.MapSpan.FromCenterAndRadius(new Xamarin.Forms.GoogleMaps.Position(37, -122), Xamarin.Forms.GoogleMaps.Distance.FromKilometers(10)));
            //var map = new Xamarin.Forms.Maps.Map(Xamarin.Forms.Maps.MapSpan.FromCenterAndRadius(new Xamarin.Forms.Maps.Position(37, -122), Xamarin.Forms.Maps.Distance.FromMiles(10)));
            //var pin = new Pin()
            //{
            //    Position = new Xamarin.Forms.Maps.Position(16.43307340526658, 102.8255601788635),
            //    Label = "Some Pin!"
            //};
            //map.Pins.Add(pin);

            //var cp = new ContentPage
            //{
            //    Content = map,
            //};



            //Pin boardwalkPin = new Pin
            //{
            //    Position = new Xamarin.Forms.Maps.Position(16.43307340526658, 102.8255601788635),
            //    Label = "Boardwalk",
            //    Address = "Santa Cruz",
            //    Type = Xamarin.Forms.Maps.PinType.SavedPin
            //};
            //VisibleRegion = MapSpan.FromCenterAndRadius(
            //    new Xamarin.Forms.GoogleMaps.Position()
            //    )
            //var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(6));
            //var location = await Geolocation.GetLocationAsync(request);


            // Map Long clicked
            //map.MapLongClicked += (sender, e) =>
            //{
            //    var lat = e.Position.Latitude.ToString("0.000");
            //    var lng = e.Position.Longitude.ToString("0.000");
            //    this.DisplayAlert("MapLongClicked", $"{lat}/{lng}", "CLOSE");
            //};
            //map.MapClicked += async (sender, e) => {


            //    var lat = e.Point.Latitude;
            //    var longs = e.Point.Longitude;
            //    await this.DisplayAlert("MapLongClicked", $"{lat}/{longs}", "CLOSE");
            //};

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(6));
                var location = await Geolocation.GetLocationAsync(request);
                //var location = await Geolocation.GetLastKnownLocationAsync();
                Xamarin.Forms.Maps.Position position = new Xamarin.Forms.Maps.Position(location.Latitude, location.Longitude);
                Xamarin.Forms.Maps.MapSpan mapSpan = new Xamarin.Forms.Maps.MapSpan(position, 0.01, 0.01);
                Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map(mapSpan)
                {
                    IsShowingUser = true
                };
                Xamarin.Forms.Maps.Pin boardwalkPin = new Xamarin.Forms.Maps.Pin
                {
                    Label = "U Plaza",
                    Address = "The city with a KhonKean",
                    Type = Xamarin.Forms.Maps.PinType.SearchResult,
                    Position = new Xamarin.Forms.Maps.Position(16.480157, 102.818123)
                    //16.43307340526658, 102.8255601788635  16.480157,102.818123
                };
                Xamarin.Forms.Maps.Pin boardwalkPin2 = new Xamarin.Forms.Maps.Pin
                {
                    Label = "โจ๊กเผาหม้อ",
                    Address = "โจ๊กกกกกกกก",
                    Type = Xamarin.Forms.Maps.PinType.SearchResult,
                    Position = new Xamarin.Forms.Maps.Position(16.483848, 102.818624)
                    //16.43307340526658, 102.8255601788635  16.480157,102.818123
                };
                map.Pins.Add(boardwalkPin);
                map.Pins.Add(boardwalkPin2);

                var listpin = new List<Xamarin.Forms.Maps.Pin>();

                //var boardwalkPin3 = new List<Xamarin.Forms.Maps.Pin>() { 
                //};
                //listpin.Add(boardwalkPin);

                //boardwalkPin2.MarkerClicked += async (s, args) =>
                //{
                //    args.HideInfoWindow = true;
                //    string pinName = ((Xamarin.Forms.Maps.Pin)s).Label;
                //    await DisplayAlert("Pin Clicked", $"{pinName} was clicked.", "Ok");
                //};
                map.MapClicked +=  async(s, arg) =>
                {
                    var x = arg.Position.Latitude;
                    var y = arg.Position.Longitude;
                    var answer = await this.DisplayAlert("แจ้งเตือน", $"ต้องการMarkใช่หรือไม่", "Yes", "CLOSE");
                    Debug.WriteLine("Answer: " + answer);
                    //this.DisplayAlert("แจ้งเตือน", $"ต้องการMarkใช่หรือไม่", "Yes", "CLOSE");
                    if (answer == true)
                    {

                        Xamarin.Forms.Maps.Pin boardwalkPinx = new Xamarin.Forms.Maps.Pin
                        {
                            Label = "โจ๊กเผาหม้อ",
                            Address = "โจ๊กกกกกกกก",
                            Type = Xamarin.Forms.Maps.PinType.SearchResult,
                            Position = new Xamarin.Forms.Maps.Position(x, y),

                            //16.43307340526658, 102.8255601788635  16.480157,102.818123
                        };
                        map.Pins.Add(boardwalkPinx);
                    }

                };


                Content = map;

                //Xamarin.Forms.GoogleMaps.Map map2 = new Xamarin.Forms.GoogleMaps.Map() {

                //};
                //map2.MapLongClicked += (sender, e) =>
                //{
                //    var lat = e.Point.Latitude.ToString("0.000");
                //    var lng = e.Point.Longitude.ToString("0.000");
                //    this.DisplayAlert("MapLongClicked", $"{lat}/{lng}", "CLOSE");
                //};
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Console.WriteLine(fnsEx);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Console.WriteLine(fneEx);
            }
            catch (PermissionException pEx)
            {
                Console.WriteLine(pEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //void OnMapClicked(object sender, MapClickedEventArgs e)
        //{
        //    var lat = e.Position.Latitude.ToString("0.000");
        //    var lng = e.Position.Longitude.ToString("0.000");
        //    this.DisplayAlert("MapLongClicked", $"{lat}/{lng}", "CLOSE");
        //    //Xamarin.Forms.Maps.Map map = new Xamarin.Forms.Maps.Map();
        //    //map.MapClicked += OnMapClicked;
        //    //{
        //    //    var lat = e.Position.Latitude.ToString("0.000");
        //    //    var lng = e.Position.Longitude.ToString("0.000");
        //    //    this.DisplayAlert("MapLongClicked", $"{lat}/{lng}", "CLOSE");
        //    //};
        //    ////System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        //    //System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        //}

        //void  clickme(object sender, Xamarin.Forms.GoogleMaps.MapClickedEventArgs e)
        // {
        //     //map.MapLongClicked += async (sender, e) =>
        //     //{
        //         var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(6));
        //         var location = await Geolocation.GetLocationAsync(request);
        //         this.DisplayAlert("MapLongClicked", $"{location.Latitude}/{location.Longitude}", "CLOSE");
        //     //};
        // }

        //async void OnInfoWindowClickedAsync(object sender, PinClickedEventArgs e)
        //{
        //    string pinName = ((Pin)sender).Label;
        //    await DisplayAlert("Info Window Clicked", $"The info window was clicked for {pinName}.", "Ok");
        //}
    }
}