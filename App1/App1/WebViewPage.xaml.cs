using System;
using System.Collections.Generic;
using App1.Data;
using Xamarin.Forms;

namespace App1
{
    public partial class WebViewPage : ContentPage
    {
        public WebViewPage(string url)
        {
            InitializeComponent();
            //wv.Source = url;
            //SaveLastUrl(url);
        }

        private async void SaveLastUrl(string url)
        {
            Properties.AppProperties["url"] = url;
            await Application.Current.SavePropertiesAsync();
        }
    }
}
