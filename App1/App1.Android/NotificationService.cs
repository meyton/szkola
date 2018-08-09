using System;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using App1.Droid;
using App1.Services.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotificationService))]
namespace App1.Droid
{
    public class NotificationService : INotificationService
    {
        NotificationManager _manager => (NotificationManager)Android.App.Application.Context.GetSystemService(Context.NotificationService);

        public void ShowNotification(string title, string message)
        {
            var intent = new Intent(Android.App.Application.Context, typeof(MainActivity));
            intent.PutExtra("TestID", "test");
            intent.AddFlags(ActivityFlags.ClearTop);

            var pendingIntent = PendingIntent.GetActivity(Android.App.Application.Context, 0, intent, PendingIntentFlags.Immutable);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(Android.App.Application.Context)
                .SetAutoCancel(true)  
                .SetContentIntent(pendingIntent)
                .SetContentTitle("Button Clicked")      // Set the title
                .SetSmallIcon(Resource.Mipmap.ic_launcher) // This is the icon to display
                .SetContentText(String.Format("The button has been clicked {0} times.", 3)); // the message to display.

            Notification notification = builder.Build();

            const int notificationId = 0;
            _manager.Notify(notificationId, builder.Build());
        }
    }
}
