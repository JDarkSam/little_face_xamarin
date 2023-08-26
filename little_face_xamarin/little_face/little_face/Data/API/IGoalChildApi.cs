using little_face.Data.Models;
using little_face.Data.Models.Dto;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Data.API
{
    public interface IGoalChildApi
    {
        [Get("/GoalChilds")]
        Task<IEnumerable<GoalChildDto>> GetGoalsChildsAsync(long userId, long chilId);
    }
}
