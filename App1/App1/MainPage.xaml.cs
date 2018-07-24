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
            if (string.IsNullOrWhiteSpace(entryUrl.Text))
            {
                await DisplayAlert("Błąd", "Musisz wpisać wiek", "OK");
                return;
            }

            var age = entryUrl.Text;

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

        private async void Button2_Clicked(object sender, EventArgs e)
        {
            if (entryUrl == null || string.IsNullOrEmpty(entryUrl.Text))
                return;
            
            var url = entryUrl.Text;
            await Navigation.PushAsync(new WebViewPage(url));
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (entryUrl == null || string.IsNullOrEmpty(entryUrl.Text))
                return;

            var url = entryUrl.Text;
            await Navigation.PushAsync(new HttpClientPage(url));
        }
    }
}