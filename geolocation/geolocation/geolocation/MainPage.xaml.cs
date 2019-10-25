using System;
using Xamarin.Forms;

namespace geolocation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void gopage01(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }
        void gopage02(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }
    }
}
