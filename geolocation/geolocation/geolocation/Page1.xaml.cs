using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace geolocation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    try
        //    {
        //        var location = await Geolocation.GetLastKnownLocationAsync();
        //        if (location != null)
        //        {
        //            Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
        //            LabelLatLong.Text = "Lat : " + location.Latitude + "Long : " + location.Longitude;
        //        }
        //    }
        //    catch (FeatureNotSupportedException fnsEx)
        //    {
        //        // Handle not supported on device exception
        //        Console.WriteLine(fnsEx);
        //    }
        //    catch (FeatureNotEnabledException fneEx)
        //    {
        //        // Handle not enabled on device exception
        //        Console.WriteLine(fneEx);
        //    }
        //    catch (PermissionException pEx)
        //    {
        //        // Handle permission exception
        //        Console.WriteLine(pEx);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Unable to get location
        //        Console.WriteLine(ex);
        //    }
        //}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                DateStart.Text = "DateStart : " + DateTime.UtcNow.ToString();
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(1));
                var location = await Geolocation.GetLocationAsync(request);
                //var location = await Geolocation.GetLastKnownLocationAsync();
                //if (location == null)
                //{
                //    location = await Geolocation.GetLocationAsync(request);
                //    //DependencyService.Get<IGetGPS>().GetGPS();
                //    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");

                //}
                LabelLatLong.Text = "Lat : " + location.Latitude + "Long : " + location.Longitude;
                DateEnd.Text = "DateEnd : " + DateTime.UtcNow.ToString();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Console.WriteLine(fnsEx);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                Console.WriteLine(fneEx);
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Console.WriteLine(pEx);
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine(ex);
            }


        }

        private async void ButtonClicked2(object sender, EventArgs e)
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(6));
                var location = await Geolocation.GetLocationAsync(request);
                //var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    LabelLatLong.Text = "Lat : " + location.Latitude + " Long : " + location.Longitude;
                }
                var location2 = new Location(location.Latitude, location.Longitude);
                var options = new MapLaunchOptions { Name = "Microsoft Building 25" };
                await Map.OpenAsync(location2, options);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                Console.WriteLine(fnsEx);
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                Console.WriteLine(fneEx);
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                Console.WriteLine(pEx);
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine(ex);
            }
        }

        private async void ButtonClicked3(object sender, EventArgs e)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(6));
            var x = await Geolocation.GetLocationAsync(request);
            //var location = await Geolocation.GetLastKnownLocationAsync();
            var location2 = new Location(16.43307340526658, 102.8255601788635);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };
            var data = Map.OpenAsync(location2, options);
            double distance = Location.CalculateDistance(x, location2, DistanceUnits.Kilometers);
        }



    }
}