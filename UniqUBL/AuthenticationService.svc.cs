﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UniqUBL;
using UniqUBL.DataAccessService;

namespace UniqUBL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AuthenticationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AuthenticationService.svc or AuthenticationService.svc.cs at the Solution Explorer and start debugging.
    public class AuthenticationService : IAuthenticationService
    {
        public bool AuthenticateWebSiteUser(string email, string passwordHash)
        {
            var client = new DataAccessServiceClient("BasicHttpBinding_IDataAccessService");
            User[] user = client.GetUser(email);
            if(user.Length > 1)
                throw new InvalidDataException();
            return user[0].PasswordHash.Equals(passwordHash);
        }

        public Guid GetTokenAccessForMobileUser(string email, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public bool RegisterNewUser(string email, string passwordHash)
        {
            var client = new DataAccessServiceClient("BasicHttpBinding_IDataAccessService");
            User[] users = client.GetUser(email);
            if (users.Length != 0)
                return false;

            client.AddUser(email, passwordHash);
            return true;
        }
    }
}
