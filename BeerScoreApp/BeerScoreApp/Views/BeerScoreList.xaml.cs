using System;
using BeerScoreApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeerScoreApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BeerScoreList : ContentPage
	{
		public BeerScoreList()
		{
			InitializeComponent();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BeerScoreItem
            {
                BindingContext = new BeerScore()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new BeerScoreItem
                {
                    BindingContext = e.SelectedItem as BeerScore
                });
            }
        }
    }
}
