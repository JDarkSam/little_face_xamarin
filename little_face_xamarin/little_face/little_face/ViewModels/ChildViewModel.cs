using little_face.Data.Models;
using little_face.Data.Models.Dto;
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
    [QueryProperty(("Accion"), ("accion"))]
    public class ChildViewModel : BaseViewModel
    {
        private readonly IChildService _childService;
        private long _childId;
        private long _accion;
        private Child _child;
        public ChildViewModel(IChildService childService) 
        { 
            _childService = childService;
            AppearingCommand = new AsyncCommand(async () => await Appearing());
        }

        public Child Child { get => _child; set => SetProperty(ref _child, value); }
        public long ChildId { get => _childId; set => SetProperty(ref _childId, value); }
        public long Accion { get => _accion; set => SetProperty(ref _accion, value); } //0=Insert 1=Update
        public ICommand AppearingCommand { get; set; }

        private async Task Appearing()
        {
            await LoadChild();
        }

        private async Task LoadChild()
        {
      
            IsBusy = true;
            try
            {
                if (Accion == 1)
                {
                    //update
                    Child = await _childService.GetChild(ChildId);

                }
                else { 
                    //insert
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
