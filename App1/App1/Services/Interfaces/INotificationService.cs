using System;
namespace App1.Services.Interfaces
{
    public interface INotificationService
    {
        void ShowNotification(string title, string message);
    }
}
