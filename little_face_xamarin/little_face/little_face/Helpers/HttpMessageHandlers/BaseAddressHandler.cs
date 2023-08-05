using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;

namespace little_face.Helpers.HttpMessageHandlers
{
    public class BaseAddressHandler : DelegatingHandler
    {
        public BaseAddressHandler()
        {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;


            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }

}
