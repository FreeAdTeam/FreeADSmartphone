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
        HomeViewModel vm;
		public Home()
        {
            vm = new HomeViewModel();

			BindingContext = vm;
            InitializeComponent();
			Title="Advertisement platform";
			CategoryPicker.Title = "Category Setting Default All";
			CategoryPicker.Items.Add("All");
			CategoryPicker.Items.Add("Companies");
			CategoryPicker.Items.Add("Recruits");
			CategoryPicker.Items.Add("RentRooms");
			CategoryPicker.Items.Add("Products");
			CategoryPicker.Items.Add("PersonalInfo");
			CategoryPicker.SelectedIndexChanged += (sender, args) =>
			{
				var search=string.IsNullOrEmpty(SearchBar.Text)?"none":SearchBar.Text.Trim();
				if (CategoryPicker.SelectedIndex == -1)
				{
					LoadData(null,search);
				}
				else
				{
					string category = CategoryPicker.Items[CategoryPicker.SelectedIndex];
					LoadData(category,search);
				}
			};
			SearchBar.SearchCommand = new Command (() => {
				string category =CategoryPicker.SelectedIndex ==-1?null: CategoryPicker.Items[CategoryPicker.SelectedIndex];
				var search=string.IsNullOrEmpty(SearchBar.Text)?"none":SearchBar.Text.Trim();
				LoadData (category,search);
			});
			SearchBar.TextChanged += MySearchBarOnTextChanged;
            LoadData();
        }

		private void MySearchBarOnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
		{
			// Has Cancel has been pressed?
			if (string.IsNullOrEmpty(textChangedEventArgs.NewTextValue ))
			{
				string category =CategoryPicker.SelectedIndex ==-1?null: CategoryPicker.Items[CategoryPicker.SelectedIndex];
				LoadData (category);
			}
		}
		private async void LoadData(string category=null,string search="none")
        {
			advertisementListView.ItemsSource = await vm.Ads(category,search);
        }

        public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            var ad = e.Item as Advertisement;
            var detail = new AdvertisementDetail(ad);
            Navigation.PushAsync(detail);
        }
    }
}
