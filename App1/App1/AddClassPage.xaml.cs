using System;
using System.Collections.Generic;
using App1.Model;
using Xamarin.Forms;

namespace App1
{
    public partial class AddClassPage : ContentPage
    {
        public AddClassPage()
        {
            BindingContext = this;
            InitializeComponent();
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (entryName == null || string.IsNullOrWhiteSpace(entryName.Text))
            {
                await DisplayAlert("Błąd", "Pole nie zostało wypełnione", "OK");
                return;
            }

            var category = new Category() { Name = entryName.Text };

            await App.LocalDB.SaveItemAsync(category);

            await DisplayAlert("Sukces", "Dane zapisane", "OK");

            await Navigation.PopAsync();
        }

        public KeyValuePair<string,string> Margin { 
            get => new KeyValuePair<string,string>("Klucz", "Wartość"); }
    }
}
