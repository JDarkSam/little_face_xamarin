using little_face.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace little_face.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}