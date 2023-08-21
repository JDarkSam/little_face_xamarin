using little_face.Data.Models;
using little_face.Services;
using little_face.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace little_face.ViewModels
{
    public class GoalsViewModel : BaseViewModel
    {
        private readonly IGoalService _goalService;
        private readonly IAppUserSettingService _appUserSettingService;


        public GoalsViewModel(IGoalService goalService, IAppUserSettingService appUserSettingService)
        {
            _goalService = goalService;
            _appUserSettingService = appUserSettingService;
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
        }

        #region Properties
        public ObservableRangeCollection<Goal> Goals { get; set; } = new ObservableRangeCollection<Goal>();

        public ICommand AppearingCommand { get; set; }
        public ICommand ClientTappedCommand { get; set; }

        #endregion

        private async Task OnAppearingAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                Int16 userId = Int16.Parse(_appUserSettingService.UserId);
                var goals = await _goalService.GetGoalsAsync(userId);
                if (goals != null)
                {
                    Goals.ReplaceRange(goals);
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private Task OnClientTapped(Goal goal)
        {
            if (goal == null)
            {
                return Task.CompletedTask;
            }

            return Shell.Current.GoToAsync($"{nameof(GoalPage)}");
        }


    }
}
