using System;
using System.ComponentModel;
namespace PhoneApp
{
	public class ContactViewModel:INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public String URL{ get; set;}
		public ContactViewModel ()
		{
			WebViewShow = false;
			IndicatorShow = true;
		}
		private bool webViewShow;
		public bool WebViewShow { get{ return webViewShow; } set{
				if (webViewShow != value)
				{
					webViewShow = value;
					OnPropertyChanged("WebViewShow");
				}
			}
		}
		private bool indicatorShow;
		public bool IndicatorShow { get{ return indicatorShow; } set{
				if (indicatorShow != value)
				{
					indicatorShow = value;
					OnPropertyChanged("IndicatorShow");
				}
			}
		}
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this,
					new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

