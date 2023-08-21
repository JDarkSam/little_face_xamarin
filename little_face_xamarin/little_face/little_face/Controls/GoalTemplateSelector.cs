using little_face.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace little_face.Controls
{
    public class GoalTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object goalObject, BindableObject container)
        {
            if (!(goalObject is Goal goal))
            {
                return DefaultTemplate;
            }

            return DefaultTemplate;
        }
    }
}
