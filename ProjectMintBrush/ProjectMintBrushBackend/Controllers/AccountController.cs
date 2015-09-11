using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectMintBrushBackend.Models;
namespace ProjectMintBrushBackend.Controllers
{
    public class AccountController : ApiController
    {
        public IHttpActionResult GetAccount(string account)
        {
            return Ok("it worked " + account);
        }
    }
}
