using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMintBrushFrontend.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult AccountApiTest()
        {
            return View();
        }

        public ActionResult EventApiTest()
        {
            return View();
        }
    }
}