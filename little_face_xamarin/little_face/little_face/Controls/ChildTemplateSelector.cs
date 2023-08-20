using little_face.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace little_face.Controls
{
    public class ChildTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object childObject, BindableObject container)
        {
            if (!(childObject is Child child))
            {
                return DefaultTemplate;
            }

            return DefaultTemplate;
        }
    }
}
