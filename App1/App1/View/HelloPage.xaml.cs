using System;
using System.Collections.Generic;
using App1.ViewModel;
using Xamarin.Forms;

namespace App1.View
{
    public partial class HelloPage : ContentPage
    {
        public HelloPage()
        {
            InitializeComponent();
            BindingContext = new HelloViewModel();
        }
    }
}
