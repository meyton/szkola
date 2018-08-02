using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using App1.Data;
using Newtonsoft.Json;
using App1.Model.Cloud;

namespace App1
{
    public partial class HttpClientPage : ContentPage
    {
        private string _url;
        private Services.HttpService _httpService;
        public HttpClientPage(string url)
        {
            _httpService = new Services.HttpService();
            _url = url;
            InitializeComponent();
            if (Properties.AppProperties.ContainsKey("url"))
                entryUrl.Text = Properties.AppProperties["url"].ToString();
        }

        private async void Handle_Clicked(object sender, System.EventArgs e)
        {
            //var comments = await _httpService.GetComments();
            //var posts = await _httpService.GetPosts();
            var comment = new Comment()
            {
                Body = "To nasz koment",
                Email = "email@testowy.pl",
                Name = "Komentujący",
                PostId = 9877,
                Id = 7454
            };

            var result = await _httpService.PatchComment(comment);
            await DisplayAlert("Sukces", $"Otrzymano odpowiedź: {result}", "OK");
        }
    }

}