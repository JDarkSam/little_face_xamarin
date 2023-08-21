using little_face.Data.API;
using little_face.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Services
{
    public class GoalService : IGoalService
    {
        private readonly IGoalApi _goalApi;
        public GoalService(IGoalApi goalApi)
        {
            _goalApi = goalApi;
        }

        public async Task<List<Goal>> GetGoalsAsync(long userId)
        {
            var goals = new List<Goal>();

            try
            {
                var response = await _goalApi.GetGoalsAsync(userId);
                goals = response.ToList();
                return goals;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return goals;
        }
    }
}
