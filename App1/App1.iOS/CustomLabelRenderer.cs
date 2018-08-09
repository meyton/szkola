using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace App1.iOS
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
        }
    }
}
