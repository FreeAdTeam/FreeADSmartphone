using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PhoneApp
{
	public partial class Manual : ContentPage
	{
		WebView webView;
		ActivityIndicator indicator;
		public Manual ()
		{
			Title = "Manual";
			indicator = UIComponents.indicator;
			var layout = new StackLayout();
			webView = UIComponents.GetWebView ("http://ouroptions.co.nz/PoneAdvertisement/Manual/40");
			webView.Navigated += webviewNavigated;
			webView.Navigating += webviewNavigating;
			layout.Children.Add(webView);
			layout.Children.Add(indicator);
			Content = layout;
			InitializeComponent ();
		}
		void webviewNavigating(object sender, WebNavigatingEventArgs e)
		{
			webView.HeightRequest = 0;
			this.indicator.IsVisible = true;
		}
		void webviewNavigated(object sender, WebNavigatedEventArgs e)
		{
			webView.HeightRequest = 1000;
			this.indicator.IsVisible = false;
		}
	}
}

