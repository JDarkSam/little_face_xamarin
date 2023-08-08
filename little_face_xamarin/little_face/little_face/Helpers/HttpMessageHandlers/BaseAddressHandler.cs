using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using little_face.Services;
using System.Net.Http.Headers;

namespace little_face.Helpers.HttpMessageHandlers
{
    public class BaseAddressHandler : DelegatingHandler
    {
        private readonly IAppUserSettingService _appUserSettingService;
        public BaseAddressHandler(IAppUserSettingService appUserSettingService)
        {
            _appUserSettingService = appUserSettingService;
        }


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            if (!request.RequestUri.AbsolutePath.EndsWith("Login"))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _appUserSettingService.UserToken);
            }


            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }

}
