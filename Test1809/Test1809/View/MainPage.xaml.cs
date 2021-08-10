using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1809.Interface;
using Xamarin.Forms;

namespace Test1809
{
    public partial class MainPage : ContentPage
    {
        IServiceFirebaseAnalytics eventTracker;
        public MainPage()
        {
            InitializeComponent();
            eventTracker = DependencyService.Get<IServiceFirebaseAnalytics>();

            webViewExtended.LogEvent((name, dictParams) => eventTracker?.SendEvent(name, dictParams));
            webViewExtended.RegisterAction((name, jsonParams) => DisplayAlert("Alert", name + " " + jsonParams, "OK"));
        }
        /*
        private void wve_SearchPressed(object sender, System.EventArgs e)
        {
            DisplayAlert("Alert", "Button pressed", "Ok");
        }

        private void btnText_Clicked(object sender, System.EventArgs e)
        {
            wve.SetSearchText("DevsDNA");
        }

        private void btnSearch_Clicked(object sender, System.EventArgs e)
        {
            wve.DoSearch();
        }

        private void btnObserve_Clicked(object sender, System.EventArgs e)
        {
            wve.Observe();
        }*/
    }
}
