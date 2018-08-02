using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Utils
{
    public sealed class UINotificationService
    {
        public static async Task<bool> DisplayQuestion(string title, string message)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, "TAK", "NIE");
        }
    }
}
