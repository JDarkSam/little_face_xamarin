using little_face.Services;
using little_face.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace little_face
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
