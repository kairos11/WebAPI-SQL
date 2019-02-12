using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLogin.Common
{
    public static class Utilities
    {

        public enum ResponseCode
        {

            Ok = 200,
            InternalError = 500,
            NotAuthorized = 403,
            InvalidPassword = 402,
            InvalidUsername = 401,
            DatabaseError = 300,
            ValidationError = 301,
            NoRecordFound = 303,
            NoContent = 204

        }

    }
}
