using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            lblHello.Text = "WSEI Szkoła programowania welcome to";
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(entryAge.Text))
            {
                await DisplayAlert("Błąd", "Musisz wpisać wiek", "OK");
                return;
            }

            var age = entryAge.Text;

            bool result = await DisplayAlert($"Masz {age} lat", "Czy masz ukończone 18 lat, by przejść na stronę?", "TAK", "NIE");
            if (result)
            {
                await Navigation.PushAsync(new SecondPage());
            }
            else
            {
                await DisplayAlert("OK", "Nie przechodzimy na stronę", "OK");
            }
        }
    }
}