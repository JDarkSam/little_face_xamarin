using little_face.Data.API;
using little_face.Resx;
using little_face.Services;
using little_face.Views;
using System.Threading;
using Xamarin.Forms;

namespace little_face.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private readonly IAccountService _accountService;

        public LoginViewModel(IAccountService accountService)
        {
            _accountService = accountService;
            LoginCommand = new Command(OnLoginClicked);
        }


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

   

        private async void OnLoginClicked(object obj)
        {
            bool a = await _accountService.LoginAsync(Username, Password);
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            if (ValidateFields() && await _accountService.LoginAsync(Username, Password))
            {
                await Shell.Current.GoToAsync($"//{nameof(ChildsPage)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                        AppResources.LoginPageInvalidLoginTitle,
                        AppResources.LoginPageInvalidLoginMessage,
                        AppResources.OkText);
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
