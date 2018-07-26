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

		public App ()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart ()
		{
            //var recipe = await LocalDB.GetItemById<Recipe>(1);
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
