using System;
using BeerScoreApp.Models;
using Xamarin.Forms;

namespace BeerScoreApp.Views
{
	public partial class BeerScoreItem : ContentPage
	{
		public BeerScoreItem()
		{
			InitializeComponent();
		}

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var beerScore = (BeerScore)BindingContext;
            await App.Database.SaveItemAsync(beerScore);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var beerScore = (BeerScore)BindingContext;
            await App.Database.DeleteItemAsync(beerScore);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        const int StepValue = 1;
		void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
		{
            var newStep = Math.Round(e.NewValue / StepValue);
            slScore.Value = newStep * StepValue;
            lblScoreValue.Text = slScore.Value.ToString();
        }
	}
}
