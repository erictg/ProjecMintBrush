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
        // /api/account/putacount?username=[username]&password=[password]&email=[email]
        [HttpPost]
        public HttpResponseMessage PostAccount(AccountModel json)
        {
            //var newAccount = AccountModel.CreateAccount(username, password, email);
            json.ID = IdentificationNumber.NewID();
            json.EntriesOwned = new List<IdentificationNumber>();
            json.EventsOwned = new List<IdentificationNumber>();
            json.CommentEntries = new List<IdentificationNumber>();
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

        //api/account/updateaccount
        //[Authorize]
        [AcceptVerbs("UPDATE")]
        public void UpdateAccount(TransferObject obj)
        {
            try
            {
                if (obj.isAdding)
                {
                    SQLCommand.ExecuteQueryAddEntryToListAccount(obj.hexCode, obj.idToUpdate, obj.listToUpdate);
                }
                else
                {
                    SQLCommand.ExecuteQueryRemoveEntryFromListAccount(obj.hexCode, obj.idToUpdate, obj.listToUpdate);
                }
                //return "Sucess";
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                //return "Failed";
            }
        }

        //api/account/RemoveAccount?hexcode=[hexcode]&username=[username]&password=[password]&email=[email]
        //[Authorize]
        [HttpDelete]
        public HttpResponseMessage DeleteAccount(AccountModel model)
        {
            try
            {
                SQLCommand.ExecuteQueryRemoveAccount(model.ID.ID, model.Username, model.Password, model.Email);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
            
            
        }
    }
    public class TransferObject
    {
        public string idToUpdate { get; set; }
        public string listToUpdate { get; set; }
        public string hexCode { get; set; }
        public bool isAdding { get; set; }
    }
}
