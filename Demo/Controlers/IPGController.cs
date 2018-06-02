using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPGGatewayAPILibrary;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controlers
{
    [Route("ipg")]
    public class IPGController : Controller
    {
        [HttpPost("notify")]
        [Consumes("application/x-www-form-urlencoded")]
        public string Notify(IPGNotify data)
        {
            if (ModelState.IsValid)
                return "OK";
            else
                return "NotOK";
        }
    }
}