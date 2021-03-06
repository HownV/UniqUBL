﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UniqUBL
{ 
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAuthenticationService" in both code and config file together.
    [ServiceContract]
    public interface IAuthenticationService
    {
        [OperationContract]
        Guid GetTokenAccessForMobileUser(string email, string passwordHash);

        [OperationContract]
        bool AuthenticateWebSiteUser(string email, string passwordHash);

        [OperationContract]
        bool RegisterNewUser(string email, string passwordHash);
    }
}
