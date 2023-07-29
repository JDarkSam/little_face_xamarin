using little_face.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace little_face.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetClientsAsync();
    }
}
