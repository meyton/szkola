using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App1.ViewModel;
using Xamarin.Forms;

namespace App1.Template
{
    public partial class MasterPage : ContentPage
    {
        private bool _isAnimating;
        public MasterPage()
        {
            InitializeComponent();
        }

        public Xamarin.Forms.View MainContent
        {
            get => mainContent.Content;
            set => mainContent.Content = value;
        }

        protected override bool OnBackButtonPressed()
        {
            if (((BaseViewModel)BindingContext).IsBusy)
                return true;

            return base.OnBackButtonPressed();
        }


        void Handle_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsVisible")
            {
                if (((StackLayout)sender).IsVisible)
                {
                    _isAnimating = true;
                    StartAnimation();
                }
                else
                {
                    _isAnimating = false;
                }
            }
        }


        private async void StartAnimation()
        {
            int i = 1;
            while (_isAnimating)
            {
                loader.Source = ImageSource.FromFile($"loader{i}.png");
                i++;
                if (i > 12)
                    i = 1;

                await Task.Delay(50);
            }
        }
    }
}
