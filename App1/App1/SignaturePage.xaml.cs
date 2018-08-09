using System;
using System.Collections.Generic;
using App1.Services.Interfaces;
using Xamarin.Forms;

namespace App1
{
    public partial class SignaturePage : ContentPage
    {
        public SignaturePage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var stream = await signatureView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var filename = DependencyService.Get<IFileHelper>().SaveImageLocally(stream);
            image.Source = ImageSource.FromFile(filename);
            image.IsVisible = true;
        }
    }
}
