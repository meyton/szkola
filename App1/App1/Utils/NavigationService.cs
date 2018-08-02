using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Utils
{
    public sealed class NavigationService
    {
        public static async Task Push(Page page)
        {
            await Application.Current.MainPage.FadeTo(0.0, 2000);
            await Application.Current.MainPage.Navigation.PushAsync(page);
            await Application.Current.MainPage.FadeTo(1.0, 1500);
        }

        public static async Task Pop()
        {
            await Application.Current.MainPage.FadeTo(0.0, 2000);
            await Application.Current.MainPage.Navigation.PopAsync();
            await Application.Current.MainPage.FadeTo(1.0, 1500);
        }
    }
}
