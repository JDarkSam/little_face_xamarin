using little_face.Data.Models;
using little_face.Data.Models.Dto;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Data.API
{
    public interface IClientApi
    {
        [Get("/Clients")]
        Task<IEnumerable<Client>> GetClientsAsync();

        [Get("/Clients/{id}")]
        Task<ClientDetailDto> GetClient(long id);

    }
}
