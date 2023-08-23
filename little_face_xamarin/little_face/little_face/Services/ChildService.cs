using little_face.Data.API;
using little_face.Data.Models;
using little_face.Data.Models.Dto;
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

        public async Task<Child> GetChild(long Id)
        {
            var child = new Child();

            try
            {
                child = await _childApi.GetChild(Id);
                return child;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return child;
        }
    }
}
