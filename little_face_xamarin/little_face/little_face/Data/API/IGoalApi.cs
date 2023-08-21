using little_face.Data.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Data.API
{
    public interface IGoalApi
    {
        [Get("/Goals")]
        Task<IEnumerable<Goal>> GetGoalsAsync(long userId);
    }
}
