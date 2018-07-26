using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using App1.Data;

namespace App1
{
    public partial class HttpClientPage : ContentPage
    {
        private string _url;
        public HttpClientPage(string url)
        {
            _url = url;
            InitializeComponent();
            if (Properties.AppProperties.ContainsKey("url"))
                entryUrl.Text = Properties.AppProperties["url"].ToString();
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_url);
                await DisplayAlert("Strona odpowiedziała", $"Kod zwrócony przez stronę: {response.StatusCode}", "OK");
            }

            var test = new Test();
            test.ToString();
        }

        private class Test
        {

        }


    }

}