using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Media;
using Xamarin.Forms;
using ZXing.Mobile;

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

            if (CrossConnectivity.IsSupported)
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("BŁĄD", "Nie ma internetu", "OK");
                    return;
                }
            }
            
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

        private async void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CategoriesPage());
        }

        async void Handle_Clicked_2(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new View.HelloPage());
        }

        async void TakePhoto_Clicked(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg",
                SaveToAlbum = true
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        async void PickPhoto_Clicked(object sender, System.EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported || string.IsNullOrEmpty(entryUrl.Text))
            {
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions()
            {
                CompressionQuality = int.Parse(entryUrl.Text),
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 800
            });

            if (file == null)
                return;

            await DisplayAlert("File size", $"File Size: {file.GetStream().Length}", "OK");

            image.Source = ImageSource.FromFile(file.Path);
        }

        async void Scan_Clicked(object sender, System.EventArgs e)
        {

            var scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null)
                await DisplayAlert("OK", "Scanned Barcode: " + result.Text, "OK");
        }
    }
}

// OAuth2
// done - Web Serwisy
// Sockety
// done - QR code - kreskowy
// Trzymanie danych w aplikacji
// Activity indicator - domyślny, sekwencja PNGów, Lottie