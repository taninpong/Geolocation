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
            return false;
        }

        //public bool Getvalue()
        //{
        //    var url = new NSUrl($"app-settings:");
        //    UIApplication.SharedApplication.OpenUrl(url); 
        //}

        void IGetGPS.GetGPS()
        {
            var url = new NSUrl($"app-settings:");
            UIApplication.SharedApplication.OpenUrl(url);
        }
    }
}