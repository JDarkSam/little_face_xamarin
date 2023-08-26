using little_face.Data.API;
using little_face.Data.Models;
using little_face.Data.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Services
{
    public class GoalChildService: IGoalChildService
    {
        private readonly IGoalChildApi _goalChildApi;
        public GoalChildService(IGoalChildApi goalChildApi)
        {
            _goalChildApi = goalChildApi;
        }

        public async Task<List<GoalChildDto>> GetGoalsChildsAsync(long userId, long childId)
        {
            var goalschilds = new List<GoalChildDto>();

            try
            {
                var response = await _goalChildApi.GetGoalsChildsAsync(userId, childId);
                goalschilds = response.ToList();
                return goalschilds;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return goalschilds;
        }
    }
}
