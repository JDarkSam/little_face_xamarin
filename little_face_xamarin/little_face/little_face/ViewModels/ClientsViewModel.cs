using little_face.Data.Models;
using little_face.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace little_face.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;
        public ClientsViewModel(IClientService clientService)
        {
            _clientService = clientService;
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());

        }

        #region Properties
        public ObservableRangeCollection<Client> Clients { get; set; } = new ObservableRangeCollection<Client>();

        public ICommand AppearingCommand { get; set; }
        #endregion

        private async Task OnAppearingAsync()
        {
            await LoadData();
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



    }
}
