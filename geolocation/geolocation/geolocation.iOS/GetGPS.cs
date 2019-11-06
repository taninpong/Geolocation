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
            //var url = new NSUrl("App-Prefs:root=Privacy&path=LOCATION_SERVICES");
            //var url = new NSUrl("App-Prefs:root=Privacy&path=LOCATION");
            //NSString settingsString = UIApplication.OpenSettingsUrlString;
            //NSUrl url = new NSUrl(settingsString);
            //UIApplication.SharedApplication.OpenUrl(url);

            //var manager = new CLLocationManager();
            //var location = manager.Location;
            var data = CLLocationManager.LocationServicesEnabled;
            if (data == false)
            {
                var url = new NSUrl($"app-settings:privacy");
                UIApplication.SharedApplication.OpenUrl(url);
                //var url = new NSUrl("App-Prefs:root=PRIVACY&path=LOCATION_SERVICES");
                //UIApplication.SharedApplication.OpenUrl(url);
            }
            else
            {
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