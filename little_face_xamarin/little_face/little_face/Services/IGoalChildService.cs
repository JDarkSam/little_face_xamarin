using little_face.Data.Models;
using little_face.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Services
{
    public interface IGoalChildService
    {
        Task<List<GoalChildDto>> GetGoalsChildsAsync(long userId, long childId);
    }
}
