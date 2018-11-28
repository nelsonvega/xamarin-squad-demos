using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xs.demos.backend.Services;
using xs.demos.backend.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace xs.demos.backend
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        public static string AzureBackendUrl = "http://localhost:5000";
        public static bool UseMockDataStore = true;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<DataStore>();
            
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
