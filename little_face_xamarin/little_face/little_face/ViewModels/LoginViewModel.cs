using little_face.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace little_face.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            if (ValidateFields())
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }

        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
            return true;
        }

    }
}
