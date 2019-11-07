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
                if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
                {
                    UIApplication.SharedApplication.OpenUrl(new NSUrl("Prefs:root=Privacy&path=LOCATION"));
                }
                else
                {
                    UIApplication.SharedApplication.OpenUrl(new NSUrl("App-Prefs:root=Privacy&path=LOCATION"));
                }
                //var url = new NSUrl("App-Prefs:root=Privacy&path=LOCATION");
                //UIApplication.SharedApplication.OpenUrl(url);
                //var url = new NSUrl("App-Prefs:root=PRIVACY&path=LOCATION_SERVICES");
                //UIApplication.SharedApplication.OpenUrl(url);
            }
            else if (CLLocationManager.Status == CLAuthorizationStatus.Denied ||
                     CLLocationManager.Status == CLAuthorizationStatus.NotDetermined ||
                     CLLocationManager.Status == CLAuthorizationStatus.Restricted)
            {
                var xxx = UIApplication.OpenSettingsUrlString;
                UIApplication.SharedApplication.OpenUrl(new NSUrl(xxx));
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