using PhoneApp.Models;
using PhoneApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PhoneApp
{
    public partial class Home : ContentPage
    {
        MainViewModel vm;
		public Home()
        {
            vm = new MainViewModel();
			Title="Advertisement platform";
            InitializeComponent();
            LoadData();
        }

		public async void OnSearch(object sender, EventArgs e)
		{
//			var temp=await GlobalAccessor.Instance.Gateway.AdminGetInventory(SearchBar.Text.Trim());
//			fillStackLayoutList (temp);
		}
        private async void LoadData()
        {
            advertisementListView.ItemsSource = await vm.Ads();
			//Layout.Children.Remove (indicator);
        }

        public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var ad = e.Item as Advertisement;
            var detail = new AdvertisementDetail(ad);
            Navigation.PushAsync(detail);
        }
    }
}
