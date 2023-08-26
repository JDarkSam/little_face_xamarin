using little_face.Data.Models;
using little_face.Services;
using little_face.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace little_face.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;
        private bool _isRefreshing = false;
        public ClientsViewModel(IClientService clientService)
        {
            _clientService = clientService;
            RefreshCommand = new AsyncCommand(OnRefresh);
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            ClientTappedCommand = new AsyncCommand<Client>(OnClientTapped);
        }

        #region Properties
        public ObservableRangeCollection<Client> Clients { get; set; } = new ObservableRangeCollection<Client>();

        public ICommand AppearingCommand { get; set; }
        public ICommand ClientTappedCommand { get; set; }

        public ICommand RefreshCommand { get; set; }

        public bool IsRefreshing { get => _isRefreshing; set => SetProperty(ref _isRefreshing, value); }


        #endregion

        private async Task OnAppearingAsync()
        {
            //await LoadData();
            IsRefreshing = true;
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                var clients = await _clientService.GetClientsAsync();
                if (clients != null)
                {
                    Clients.ReplaceRange(clients);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private Task OnClientTapped(Client client)
        {
            if (client == null)
            {
                return Task.CompletedTask;
            }

            return Shell.Current.GoToAsync($"{nameof(ClientPage)}?{nameof(ClientViewModel.ClientId)}={client.Id}");
        }

        private async Task OnRefresh()
        {
            await LoadData();
            IsRefreshing = false;
        }

    }
}
