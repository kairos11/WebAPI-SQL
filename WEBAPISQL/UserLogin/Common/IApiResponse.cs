using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLogin.Common
{
    public interface IApiResponse
    {

            string ResponseCode { get; set; }
            string Message { get; set; }
    }
}
