using little_face.Data.Models;
using little_face.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace little_face.ViewModels
{
    [QueryProperty(nameof(ChildId), nameof(ChildId))]
    public class ChildViewModel : BaseViewModel
    {
        private readonly IChildService _childService;
        private long _childId;

        public ChildViewModel(IChildService childService) 
        { 
            _childService = childService;
            AppearingCommand = new AsyncCommand(async () => await Appearing());
        }

        public long ChildId { get => _childId; set => SetProperty(ref _childId, value); }
        public ICommand AppearingCommand { get; set; }

        private async Task Appearing()
        {
            await LoadChild();
        }

        private async Task LoadChild()
        {
            if (ChildId < 0)
            {
                return;
            }

            IsBusy = true;
            try
            {
                var a = await _childService.GetChildsAsync(1);
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
