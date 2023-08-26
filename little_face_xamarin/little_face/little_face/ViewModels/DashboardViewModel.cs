using Syncfusion.SfCalendar.XForms;
using System;
using FreshMvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace little_face.ViewModels
{
    public class DashboardViewModel :BaseViewModel
    {

        public CalendarEventCollection CalendarInlineEvents { get; set; } = new CalendarEventCollection();
        public DashboardViewModel()
        {
            CalendarInlineEvent event1 = new CalendarInlineEvent();
            event1.StartTime = new DateTime(2023, 8, 20, 5, 0, 0);
            event1.EndTime = new DateTime(2023, 8, 25, 7, 0, 0);
            event1.Subject = "Carita Feliz";
            event1.Color = Color.FromHex("#f5be0b");//Color.Yellow;
            event1.IsAllDay = true;

            CalendarInlineEvent event2 = new CalendarInlineEvent();
            event2.StartTime = new DateTime(2023, 8, 20, 10, 0, 0);
            event2.EndTime = new DateTime(2023, 8, 20, 12, 0, 0);
            event2.Subject = "Carita Triste";
            event2.Color = Color.Red;
            event2.IsAllDay = true;

            CalendarInlineEvents.Add(event1);
            CalendarInlineEvents.Add(event2);
        }


    }
}
