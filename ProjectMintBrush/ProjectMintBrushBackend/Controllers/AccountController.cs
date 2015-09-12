﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectMintBrushBackend.Models;
using ProjectMintBrushBackend;

namespace ProjectMintBrushBackend.Controllers
{
    public class AccountController : ApiController
    {
        // /api/account/addacount?username=[username]&password=[password]&email=[email]
        [HttpGet]
        public IHttpActionResult AddAccount(string username, string password, string email)
        {
            var newAccount = AccountModel.CreateAccount(username, password, email);
            SQLCommand.ExecuteQuery("INSERT INTO dbo.Users VALUES ('" + newAccount.ID.ID + "','" + newAccount.Username + "','" + newAccount.Password + "','" + newAccount.Email + "')");
            SQLCommand.ExecuteQuery("INSERT INTO dbo.IdentificationNumbers VALUES('" + newAccount.ID.ID + "')");
            return Json<AccountModel>(newAccount);
        }
    }
}
