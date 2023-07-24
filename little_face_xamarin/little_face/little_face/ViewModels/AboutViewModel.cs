using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace little_face.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private string _showMesage2;

        public string ShowMesage2
        {

            get => _showMesage2;
            set
            {
                if (_showMesage2 != value)
                {
                    _showMesage2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public AboutViewModel()
        {
            Title = "About";
            ShowMesage2 = "Haz iniciado sesion correctamente";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}