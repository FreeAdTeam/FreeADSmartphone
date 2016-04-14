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
			vm.URL="Http://arthurcv.com/";
			Title="Contact US";
			BindingContext = vm;
			InitializeComponent ();
		}
		void webviewNavigating(object sender, WebNavigatingEventArgs e)
		{
			vm.WebViewShow = false;
			vm.IndicatorShow = true;
		}
		void webviewNavigated(object sender, WebNavigatedEventArgs e)
		{
			vm.WebViewShow = true;
			vm.IndicatorShow = false;
		}
	}
}

