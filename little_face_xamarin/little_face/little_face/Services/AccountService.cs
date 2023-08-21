﻿using little_face.Data.API;
using little_face.Data.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace little_face.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountApi _accountApi;
        private readonly IAppUserSettingService _appUserSettingService;

        public AccountService(IAccountApi accountApi, IAppUserSettingService appUserSettingService)
        {
            _accountApi = accountApi;
            _appUserSettingService = appUserSettingService;
        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            try
            {
                var response = await _accountApi.LoginAsync(userName, password);

                if (response == null || response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    return false;
                }
                else
                {
                    var stringResponse = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<UserDto>(stringResponse);

                    if (user != null)
                    {
                        _appUserSettingService.UserName = user.UserName;
                        _appUserSettingService.UserToken = user.Token;
                        _appUserSettingService.UserId = user.Id.ToString();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
            return false;
        }
    }

}
