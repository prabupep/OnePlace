using OnePlace.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnePlace.Web.Controllers
{
    public class CalendarAPIController : ApiController
    {
        private OnePlaceEntities db = new OnePlaceEntities();
        // GET: api/ProjectsAPI
        public List<GetReleaseDetails_Result> GetReleaseDetails()
        {

            List<GetReleaseDetails_Result> value = db.GetReleaseDetails().ToList();


            return value;
        }
    }
}
