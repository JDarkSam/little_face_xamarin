using little_face.Data.API;
using little_face.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace little_face.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildApi _childApi;
        public ChildService(IChildApi childApi) 
        {
            _childApi = childApi;
        }

        public async Task<List<Child>> GetChildsAsync(long userId)
        {
            var childs = new List<Child>();

            try
            {
                var response = await _childApi.GetChildsAsync(userId);
                childs = response.ToList();
                return childs;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return childs;
        }
    }
}
