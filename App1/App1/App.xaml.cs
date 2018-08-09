using System;
using App1.Data;
using App1.Model;
using App1.Services.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace App1
{
	public partial class App : Application
	{
        private static LocalDatabase localDB;

        public static LocalDatabase LocalDB 
        { 
            get
            {
                if (localDB == null)
                {
                    var fileHelper = DependencyService.Get<IFileHelper>();
                    var file = fileHelper.GetLocalFilepath("db.db3");
                    localDB = new LocalDatabase(file);
                }

                return localDB;
            }
        }

        public NavigationPage Navi { get; set; }
		public App ()
		{
			InitializeComponent();
            Navi = new NavigationPage(new MainPage());
            MainPage = Navi;
		}

        public App(string testId)
        {
            InitializeComponent();
            Navi = new NavigationPage(new SecondPage(testId));
            MainPage = Navi;
        }

		protected override void OnStart ()
		{
            //var recipe = await LocalDB.GetItemById<Recipe>(1);
		}

		protected override void OnSleep ()
		{
            DependencyService.Get<INotificationService>().ShowNotification("", "");
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}