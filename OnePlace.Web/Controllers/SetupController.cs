using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnePlace.Web.Controllers
{
    public class SetupController : Controller
    {
        // GET: Setup
        public ActionResult Project()
        {
            return View();
        }
        public ActionResult ExternalService()
        {
            return View();
        }
        public ActionResult Languages()
        {
            return View();
        }

    }
}