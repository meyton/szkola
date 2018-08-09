using System;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class TestViewModel : BaseViewModel
    {
        public string LabelValue { get => "Witaj na stronie"; }
        public ImageSource Source1 { get => ImageSource.FromFile("loader2.png"); }
        public ImageSource Source2 { get => ImageSource.FromFile("loader6.png"); }
    }
}
