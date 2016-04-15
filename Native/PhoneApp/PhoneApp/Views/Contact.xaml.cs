using System;
using System.Collections.Generic;
using PhoneApp.ViewModels;
using Xamarin.Forms;

namespace PhoneApp
{
	public partial class Contact : ContentPage
	{
		ContactViewModel vm;
		public Contact ()
		{
			vm = new ContactViewModel ();
			Title="Contact US";
			BindingContext = vm;
			InitializeComponent ();
			ConnectButton.Clicked += OnConnectClick;
		}
		void OnConnectClick(object sender, EventArgs e){
			Device.BeginInvokeOnMainThread(() =>
				{
					vm = new ContactViewModel ();
					this.Title = "Contact US";
					BindingContext = vm;
					InitializeComponent ();
					ConnectButton.Clicked += OnConnectClick;
				});
		}
		void webviewNavigating(object sender, WebNavigatingEventArgs e)
		{
			vm.WebViewShow = false;
			vm.IndicatorShow = true;
			vm.ConnectShow = false;
		}
		void webviewNavigated(object sender, WebNavigatedEventArgs e)
		{
			if (e.Result.ToString () == "Success") {
				vm.WebViewShow = true;
				vm.IndicatorShow = false;
				vm.ConnectShow = false;
			} else {
				vm.WebViewShow = false;
				vm.IndicatorShow = false;
				vm.ConnectShow = true;
			}
		}
	}
}

