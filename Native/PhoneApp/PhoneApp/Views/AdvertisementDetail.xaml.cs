using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneApp.Models;
using Xamarin.Forms;

namespace PhoneApp
{
    public partial class AdvertisementDetail : ContentPage
    {
		AdvertisementDetailViewModel vm;
		public AdvertisementDetail(Advertisement ad)
        {
			vm = new AdvertisementDetailViewModel (ad);
            this.Title = "Detail Information";
			BindingContext = vm;
            InitializeComponent();
        }
        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
			vm.WebViewShow = false;
			vm.IndicatorShow = true;
			//webView.HeightRequest = 0;
			//this.indicator.IsVisible = true;
        }
        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
			vm.WebViewShow = true;
			vm.IndicatorShow = false;
			//webView.HeightRequest = 1000;
			//this.indicator.IsVisible = false;
        }
    }
}
