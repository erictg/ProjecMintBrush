using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectMintBrushBackend.Models;
using System.Diagnostics;
namespace ProjectMintBrushBackend.Controllers
{
    public class EventController : ApiController
    {
        [HttpPut]
        public HttpResponseMessage PutAccount(EventModel json)
        {
            try
            {
                json.ID = IdentificationNumber.NewID();
                string query = "insert into dbo.Events Values('" + json.ID + "')";
                //saves the id to the lookup db
                SQLCommand.ExecuteQuery(query);
                //saves the object to the xml database
                SQLCommand.ExecuteQuerySaveObject<EventModel>("ev", json);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
            
        }

    }
}
