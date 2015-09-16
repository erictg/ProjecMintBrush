using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectMintBrushBackend.Models;
using ProjectMintBrushBackend;
using System.Diagnostics;

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
            SQLCommand.ExecuteQuerySaveObject<AccountModel>("a", newAccount);
            return Ok(true);
        }

        // /api/account/getaccount/?hexcode=[hexcode]
        [HttpGet]
        public IHttpActionResult GetAccount(string hexcode)
        {
            AccountModel model = SQLCommand.ExecuteQueryLoadObject<AccountModel>(hexcode,"Account", "Object");
            if (model != null)
            {
                return Json<AccountModel>(model);
            }

            return Ok(400);
        }

        //api/account/updateaccount?hexcode=[hexcode]&list=[list]&newID=[newID]&table=[table]&updateID=[updateID]
        [Authorize]
        [HttpGet]
        public IHttpActionResult UpdateAccount(string hexcode, string list, string newID, string table, string updateID)
        {
            if (updateID == "a")
            {
                try
                {
                    SQLCommand.ExecuteQueryAddEntryToList(hexcode, table, newID, list);
                    return Ok(true);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                    return Ok(false);
                }
            }
            else if (updateID == "r")
            {
                try
                {
                    SQLCommand.ExecuteQueryRemoveEntryFromList(hexcode, table, newID, list);
                    return Ok(true);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                    return Ok(false);
                }
            }
            else
            {
                return Ok("invalid");
            }
            
        }

        //api/account/RemoveAccount?hexcode=[hexcode]&username=[username]&password=[password]&email=[email]
        [Authorize]
        [HttpGet]
        public IHttpActionResult RemoveAccount(string hexcode, string username, string password, string email)
        {
            try
            {
                SQLCommand.ExecuteQueryRemoveAccount(hexcode, username, password, email);
                return Ok(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return Ok(false);
            }
            
            
        }
    }
}
