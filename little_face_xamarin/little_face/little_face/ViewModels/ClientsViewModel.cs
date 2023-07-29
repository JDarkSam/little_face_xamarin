using little_face.Data.Models;
using little_face.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace little_face.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;
        public ClientsViewModel(IClientService clientService)
        {
            _clientService = clientService;
        }

        //public ObservableCollection<Client> Clients { get; set; } = new ObservableRangeCollection<Client>();

    }
}
