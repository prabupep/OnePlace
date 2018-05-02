using OnePlace.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OnePlace.Web.Controllers
{
    public class ReleaseListAPIController : ApiController
    {
        private OnePlaceEntities db = new OnePlaceEntities();
        // GET: api/ProjectsAPI
        public List<GetReleaseList_Result> GetReleaseDetails()
        {

            List<GetReleaseList_Result> value = db.GetReleaseList().ToList();


            return value;
        }
    }
}