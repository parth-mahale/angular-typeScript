using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Models
{
    public class ResultDto
    {
        public bool Result { get; set; }                           

        public string ResultMessage { get; set; }

        public string Details { get; set; }

        public HttpStatusCode Status { get; set; }

      //  public string Token { get; set; }

      //  public bool IsDeviceMaxLimitReached { get; set; }
    }
}
