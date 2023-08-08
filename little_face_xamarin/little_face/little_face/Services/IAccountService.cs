using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Services
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string userName, string password);
    }

}
