using Android.App;
using Android.Content;
using Android.Locations;
using geolocation.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(GetGPS))]
namespace geolocation.Droid
{
    public class GetGPS : IGetGPS
    {
        void IGetGPS.GetGPS()
        {
            LocationManager LM = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
            if (LM.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                Intent intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                intent.AddFlags(ActivityFlags.NewTask);
                intent.AddFlags(ActivityFlags.MultipleTask);
                Android.App.Application.Context.StartActivity(intent);
            }
        }

        bool IGetGPS.Getvalue()
        {
            LocationManager LM = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
            if (LM.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //public void OpenAppSettings()
        //{
        //    var intent = new Intent(Android.Provider.Settings.ActionApplicationDetailsSettings);
        //    intent.AddFlags(ActivityFlags.NewTask);
        //    var uri = Android.Net.Uri.FromParts("package", , null);
        //    intent.SetData(uri);
        //    Application.Context.StartActivity(intent);
        //}
    }
}