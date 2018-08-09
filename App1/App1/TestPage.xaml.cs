using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App1.Model;
using App1.Services.Interfaces;
using Plugin.LocalNotifications;
using Xamarin.Forms;

namespace App1
{
    public partial class TestPage : Template.MasterPage
    {
        private ViewModel.TestViewModel _vm;
        private INotificationService _noti;

        public TestPage(List<Recipe> recipes)
        {
            _noti = DependencyService.Get<INotificationService>();
            _vm = new ViewModel.TestViewModel();
            BindingContext = _vm;
            InitializeComponent();
            //grid.ItemsSource = recipes;
            _noti.ShowNotification("Cześć", "Tutaj Marcin");
            //CrossLocalNotifications.Current.Show("title", "body", (int)DateTime.Now.Ticks);
            //Task.Run(async () => await Init());
            _vm.IsBusy = true;
        }

        private async Task Init()
        {
            await Task.Delay(5000);
            CrossLocalNotifications.Current.Show("title", "body", (int)DateTime.Now.Ticks);
        }

        void Handle_OnFinish(object sender, System.EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
