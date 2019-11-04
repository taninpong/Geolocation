using CoreLocation;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(geolocation.iOS.GetGPS))]
namespace geolocation.iOS
{
    public class GetGPS : IGetGPS
    {
        public bool Getvalue()
        {
            //var check = NSLocationAlwaysUsageDescription();
            return false;
        }

        //public bool Getvalue()
        //{
        //    var url = new NSUrl($"app-settings:");
        //    UIApplication.SharedApplication.OpenUrl(url); 
        //}

        void IGetGPS.GetGPS()
        {
            //UIApplication.SharedApplication.OpenUrl(new NSUrl(UIKit.UIApplication.OpenSettingsUrlString));
            //var url = new NSUrl($"app-settings:");
            //var data = UIApplication.LaunchOptionsLocationKey();
            //var data = CLLocationManager.LocationServicesEnabled;
            //var url = new NSUrl("App-Prefs:root=Privacy&path=LOCATION");
            //var url = new NSUrl("App-Prefs:root=Privacy&path=LOCATION");
            //NSString settingsString = UIApplication.OpenSettingsUrlString;
            //NSUrl url = new NSUrl(settingsString);
            //UIApplication.SharedApplication.OpenUrl(url);



            if (!CLLocationManager.LocationServicesEnabled)
            {
                //Console.WriteLine("Location Services are off globally go to settings");
                // This may get your app rejected using the strings below
                if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
                {
                    UIApplication.SharedApplication.OpenUrl(new NSUrl("App-Prefs:root=Privacy&path=LOCATION"));
                }
                else
                {
                    UIApplication.SharedApplication.OpenUrl(new NSUrl("prefs:root=Privacy&path=LOCATION"));
                }
            }
            else if (CLLocationManager.Status == CLAuthorizationStatus.Denied ||
                     CLLocationManager.Status == CLAuthorizationStatus.NotDetermined ||
                     CLLocationManager.Status == CLAuthorizationStatus.Restricted)
            {
                //Console.WriteLine("Location Services are off just for your app, got to app settings");
                UIApplication.SharedApplication.OpenUrl(new NSUrl(UIApplication.OpenSettingsUrlString));
            }

            //UIApplication.SharedApplication.OpenUrl(new NSUrl("app-settings:LOCATION_SERVICES"));
            //UIApplication.SharedApplication.OpenUrl(url);
            //if (data == false)
            //{
            //    //var url = new NSUrl("App-Prefs:app-settings=LOCATION_SERVICES");
            //    UIApplication.SharedApplication.OpenUrl(url);
            //}

        }
    }
}