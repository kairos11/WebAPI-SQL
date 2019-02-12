using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLogin.Common;
using static UserLogin.Common.Utilities;

namespace UserLogin.Common
{
    public class ApiResponse : IApiResponse
    {

        string ResponseCode { get; set; }
        string Message { get; set; }

        public void CreateResponse(ResponseCode responseCode,  string message)
        {

        }

    }
}
