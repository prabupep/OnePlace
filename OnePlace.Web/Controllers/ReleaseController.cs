using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnePlace.Web.Controllers
{
    public class ReleaseController : Controller
    {
        // GET: Release
        public ActionResult Index()
        {
            return View("list");
        }
        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult NewDeployment()
        {
            return View();
        }
        public ActionResult List()
        {
            return View();
        }
    }
}