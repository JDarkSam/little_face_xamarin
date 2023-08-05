using little_face.Data.API;
using little_face.Resx;
using little_face.Services;
using little_face.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace little_face.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;
        private bool _showMessage;
        private string _welcomeMessage;
        private Color _messageColor;

        public string Username {

            get => _username;
            set {
                if (_username != value) {
                    _username = value;
                    OnPropertyChanged();
                }                
            }
        }
        public string Password
        {

            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ShowMessage
        {

            get => _showMessage;
            set
            {
                if (_showMessage != value)
                {
                    _showMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public string WelcomeMessage
        {

            get => _welcomeMessage;
            set
            {
                if (_welcomeMessage != value)
                {
                    _welcomeMessage = value;
                    OnPropertyChanged();
                }
            }
        }


        public Color MessageColor
        {

            get => _messageColor;
            set
            {
                if (_messageColor != value)
                {
                    _messageColor = value;
                    OnPropertyChanged();
                }
            }
        }


        public Command LoginCommand { get; }

        
        public LoginViewModel()
        {           
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if (ValidateFields())
            {
                if (Username == "sam" && Password == "pepito1234")
                {
                    WelcomeMessage  = "Inicio de sesión exitoso ¡Bienvenido! :" + Username;
                    MessageColor = Color.Green;
                    Thread.Sleep(2000);             
                    await Shell.Current.GoToAsync($"//{nameof(ClientsPage)}");

                }
                else
                {
                    ShowMessage = true;            
                    MessageColor = Color.Red;
                    WelcomeMessage = "Credenciales Invalidas!!!";
                    await Application.Current.MainPage.DisplayAlert(AppResources.LoginPageInvalidLoginTitle,AppResources.LoginPageInvalidLoginMessage,AppResources.OkText);
                }
                
            }

        }       
        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
            return true;
        }

    }
}
