using little_face.ViewModels;
using little_face.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace little_face
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ClientPage), typeof(ClientPage));
            Routing.RegisterRoute(nameof(ChildPage), typeof(ChildPage));
            Routing.RegisterRoute(nameof(GoalPage), typeof(GoalPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
