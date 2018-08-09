using System;
using App1.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("AppEffects")]
[assembly: ExportEffect(typeof(StrikeEffect), "StrikeEffect")]
namespace App1.Droid
{
    public class StrikeEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            var control = (Control as Android.Widget.TextView);
            if (control != null)
            {
                control.PaintFlags = Android.Graphics.PaintFlags.StrikeThruText;
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
