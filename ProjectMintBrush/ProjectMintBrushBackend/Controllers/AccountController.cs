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
        [HttpPut]
        public HttpResponseMessage PutAccount(AccountModel json)
        {
            //var newAccount = AccountModel.CreateAccount(username, password, email);
            json.ID = IdentificationNumber.NewID();
            SQLCommand.ExecuteQuery("INSERT INTO dbo.Users VALUES ('" + json.ID.ID + "','" + json.Username + "','" + json.Password + "','" + json.Email + "')");
            SQLCommand.ExecuteQuerySaveObject<AccountModel>("a", json);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
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
        [HttpPost]
        public HttpResponseMessage PostAccount(string hexcode, string list, string newID, string table, string updateID)
        {
            //a = add, r = remove
            if (updateID == "a")
            {
                try
                {
                    SQLCommand.ExecuteQueryAddEntryToList(hexcode, table, newID, list);
                    return new HttpResponseMessage(HttpStatusCode.Accepted);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                    return new HttpResponseMessage(HttpStatusCode.Conflict);
                }
            }
            else if (updateID == "r")
            {
                try
                {
                    SQLCommand.ExecuteQueryRemoveEntryFromList(hexcode, table, newID, list);
                    return new HttpResponseMessage(HttpStatusCode.Accepted);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                    return new HttpResponseMessage(HttpStatusCode.Conflict);
                }
            }
            else
            {
               return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
            
        }

        //api/account/RemoveAccount?hexcode=[hexcode]&username=[username]&password=[password]&email=[email]
        [Authorize]
        [HttpGet]
        public HttpResponseMessage DeleteAccount(string hexcode, string username, string password, string email)
        {
            try
            {
                SQLCommand.ExecuteQueryRemoveAccount(hexcode, username, password, email);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            
            
        }
    }
}
