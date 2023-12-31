﻿using little_face.Data.Models;
using little_face.Data.Models.Dto;
using little_face.Resx;
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
        private readonly IAppUserSettingService _appUserSettingService;
        private long _childId;
        private long _accion;
        private Child _child;
        private ChildDto _childDto;

        private string _names;
        private string _surnames;
        private int _age;
        private string _alias;
        private string _userId;
        private long _id;


        public string Names
        {

            get => _names;
            set
            {
                if (_names != value)
                {
                    _names = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Surnames
        {

            get => _surnames;
            set
            {
                if (_surnames != value)
                {
                    _surnames = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Age
        {

            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Alias
        {

            get => _alias;
            set
            {
                if (_alias != value)
                {
                    _alias = value;
                    OnPropertyChanged();
                }
            }
        }
        public string UserId
        {

            get => _userId;
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged();
                }
            }
        }

        public long Id
        {

            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }



        public ChildViewModel(IChildService childService, IAppUserSettingService appUserSettingService) 
        { 
            _childService = childService;
            AppearingCommand = new AsyncCommand(async () => await Appearing());
            AddUpdatechildCommand = new AsyncCommand(async () => await AddUpdatechild());
            _appUserSettingService = appUserSettingService;
        }

        public Child Child { get => _child; set => SetProperty(ref _child, value); }
        public ChildDto ChildDto { get => _childDto; set => SetProperty(ref _childDto, value); }
        public long ChildId { get => _childId; set => SetProperty(ref _childId, value); }
        public long Accion { get => _accion; set => SetProperty(ref _accion, value); } //0=Insert 1=Update
        public ICommand AppearingCommand { get; set; }

        public ICommand AddUpdatechildCommand { get; set; }

        private async Task Appearing()
        {
            if (Accion == 1) 
            {
                await LoadChild();
            }            
        }

        private async Task AddUpdatechild()
        {
            switch (Accion) 
            {
                case 0: await AddChild(); 
                    break;
                case 1: await UpdateChild();
                    break;
                default:
                    break;
            }           
        }

        private async Task AddChild()
        {
            IsBusy = true;
            try
            {
                ChildDto = new ChildDto();
                                
                ChildDto.Names = Names;
                ChildDto.Surnames = Surnames;
                ChildDto.Age = Age;
                ChildDto.Alias = Alias;
                ChildDto.UserId = Int16.Parse(_appUserSettingService.UserId);

                Child = await _childService.AddChild(ChildDto);
                await Application.Current.MainPage.DisplayAlert(
                        "Child",
                        "The child was inserted!",
                        AppResources.OkText);
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

        private async Task UpdateChild()
        {
            IsBusy = true;
            try
            {
                ChildDto = new ChildDto();

                ChildDto.Id = Id;
                ChildDto.Names = Names;
                ChildDto.Surnames = Surnames;
                ChildDto.Age = Age;
                ChildDto.Alias = Alias;
                ChildDto.UserId = Int16.Parse(_appUserSettingService.UserId);

                Child = await _childService.UpdateChild(Id,ChildDto);
                await Application.Current.MainPage.DisplayAlert(
                        "Child",
                        "the child was updated!",                        
                       AppResources.OkText);
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

        private async Task LoadChild()
        {
      
            IsBusy = true;
            try
            {                                
                Child = await _childService.GetChild(ChildId);
                Id = Child.Id;
                Names = Child.Names;
                Surnames = Child.Surnames;
                Age = Child.Age;
                Alias = Child.Alias;
                UserId = Child.UserId.ToString();               
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
