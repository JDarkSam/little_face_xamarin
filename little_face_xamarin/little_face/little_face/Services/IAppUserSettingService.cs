using System;
using System.Collections.Generic;
using System.Text;

namespace little_face.Services
{
    public interface IAppUserSettingService
    {
        string UserName { get; set; }
        string UserToken { get; set; }
        string UserId { get; set; }
        void Clear();

    }

}
