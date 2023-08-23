using little_face.Data.Models;
using little_face.Resx;
using little_face.Services;
using little_face.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace little_face.ViewModels
{    
    public class ChildsViewModel : BaseViewModel
    {
        private readonly IChildService _childService;
        private readonly IAppUserSettingService _appUserSettingService;
       
        public ChildsViewModel(IChildService childService, IAppUserSettingService appUserSettingService)
        { 
            _childService = childService;
            _appUserSettingService = appUserSettingService;
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
            ChildTappedCommand = new AsyncCommand<Child>(OnChildTapped);
            AddChildCommand = new Command(OnLoginClicked);
        }

  
        #region Properties
        public ObservableRangeCollection<Child> Childs { get; set; } = new ObservableRangeCollection<Child>();

        public ICommand AppearingCommand { get; set; }
        public ICommand ChildTappedCommand { get; set; }

        #endregion

        public Command AddChildCommand { get; }

        private async void OnLoginClicked(object obj)
        {   
            //await Shell.Current.GoToAsync($"{nameof(ChildPage)}");
            await Shell.Current.GoToAsync($"{nameof(ChildPage)}?{nameof(ChildViewModel.ChildId)}={0}&accion={0}");
        }
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
                var childs = await _childService.GetChildsAsync(userId);
                if (childs != null)
                {
                    Childs.ReplaceRange(childs);
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

        private Task OnChildTapped(Child child)
        {
            if (child == null)
            {
                return Task.CompletedTask;
            }

            return Shell.Current.GoToAsync($"{nameof(ChildPage)}?{nameof(ChildViewModel.ChildId)}={child.Id}&accion={1}");
        }

    }
}
