﻿using little_face.Data.Models;
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
    public class ChildsViewModel : BaseViewModel
    {
        private readonly IChildService _childService;
        public ChildsViewModel(IChildService childService)
        { 
            _childService = childService;
            AppearingCommand = new AsyncCommand(async () => await OnAppearingAsync());
        }

        #region Properties
        public ObservableRangeCollection<Child> Childs { get; set; } = new ObservableRangeCollection<Child>();

        public ICommand AppearingCommand { get; set; }
        public ICommand ChildTappedCommand { get; set; }

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
                var childs = await _childService.GetChildsAsync();
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

        private Task OnClientTapped(Child child)
        {
            if (child == null)
            {
                return Task.CompletedTask;
            }

            return Shell.Current.GoToAsync($"{nameof(ChildPage)}"); 
        }

    }
}