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

namespace little_face.ViewModels
{
    public class DashboardViewModel :BaseViewModel
    {

        private readonly IChildService _childService;
        private readonly IAppUserSettingService _appUserSettingService;
        public CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();
        public DashboardViewModel(IGoalChildService childService, IAppUserSettingService appUserSettingService)
        {
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
        }

        public ICommand AppearingCommand { get; set; }


        private async Task OnAppearingAsync()
        {
            await AddAppointments();
        }
        public async Task AddAppointments() 
        {
            CalendarInlineEvent event1 = new CalendarInlineEvent();
            event1.StartTime = new DateTime(2023, 8, 20, 5, 0, 0);
            event1.EndTime = new DateTime(2023, 8, 25, 7, 0, 0);
            event1.Subject = "Carita Feliz ☺";
            event1.Color = Color.FromHex("#f5be0b");//Color.Yellow;
            event1.IsAllDay = true;

            CalendarInlineEvent event2 = new CalendarInlineEvent();
            event2.StartTime = new DateTime(2023, 8, 20, 10, 0, 0);
            event2.EndTime = new DateTime(2023, 8, 20, 12, 0, 0);
            event2.Subject = "Carita Triste ☹";
            event2.Color = Color.Red;
            event2.IsAllDay = true;

            CalendarInlineEvents.Add(event1);
            CalendarInlineEvents.Add(event2);
        }

    }
}
