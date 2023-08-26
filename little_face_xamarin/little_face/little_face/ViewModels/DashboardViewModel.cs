using Syncfusion.SfCalendar.XForms;
using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using little_face.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using System.Windows.Input;
using System.Threading.Tasks;
using little_face.Data.Models;
using little_face.Data.Models.Dto;

namespace little_face.ViewModels
{
    public class DashboardViewModel :BaseViewModel
    {

        private readonly IGoalChildService _goalChildService;
        private readonly IAppUserSettingService _appUserSettingService;
        public CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();
        public DashboardViewModel(IGoalChildService goalChildService, IAppUserSettingService appUserSettingService)
        {
            _goalChildService = goalChildService;
            _appUserSettingService = appUserSettingService;
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
        }

        #region Properties
        public ICommand AppearingCommand { get; set; }
        public ObservableRangeCollection<GoalChildDto> GoalChildDto { get; set; } = new ObservableRangeCollection<GoalChildDto>();
        #endregion

        private async Task OnAppearingAsync()
        {
            await AddAppointments();
        }
        public async Task AddAppointments() 
        {

            try
            {
                IsBusy = true;
                Int16 userId = Int16.Parse(_appUserSettingService.UserId);
                var goalsChilds = await _goalChildService.GetGoalsChildsAsync(userId,1);
                if (goalsChilds != null)
                {
                    GoalChildDto.ReplaceRange(goalsChilds);
                }

             
                foreach (GoalChildDto item in GoalChildDto)
                {
                    CalendarInlineEvent eventDay = new CalendarInlineEvent();
                    eventDay.StartTime = item.DateGoal;
                    eventDay.EndTime = item.DateGoal;

                    switch (item.Face)  //happy 1, sad 2, nothing 0
                    {
                        case 1:
                            eventDay.Subject = item.Taskname + " 😀";
                            eventDay.Color = Color.FromHex("#f5be0b");
                            break;
                        case 2:
                            eventDay.Subject = item.Taskname + " 😔";
                            eventDay.Color = Color.Red;
                            break;
                        case 0:
                            eventDay.Subject = item.Taskname;
                            eventDay.Color = Color.Gray;
                            break;
                        default:
                            break;
                    }

                    eventDay.IsAllDay = true;

                    CalendarInlineEvents.Add(eventDay);                 
                   
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

    }
}
