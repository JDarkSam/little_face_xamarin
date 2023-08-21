using little_face.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Services
{
    public interface IGoalService
    {
        Task<List<Goal>> GetGoalsAsync(long userId);
    }
}
