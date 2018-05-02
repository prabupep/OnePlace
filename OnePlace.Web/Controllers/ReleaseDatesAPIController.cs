using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using OnePlace.Entity;

namespace OnePlace.Web.Controllers
{
    public class ReleaseDatesAPIController : ApiController
    {
        private OnePlaceEntities db = new OnePlaceEntities();

        // GET: api/ReleaseDatesAPI
        public IQueryable<ReleaseDate> GetReleaseDates()
        {
            return db.ReleaseDates;
        }

        // GET: api/ReleaseDatesAPI/5
        [ResponseType(typeof(ReleaseDate))]
        public IHttpActionResult GetReleaseDate(Guid id)
        {
            ReleaseDate releaseDate = db.ReleaseDates.Find(id);
            if (releaseDate == null)
            {
                return NotFound();
            }

            return Ok(releaseDate);
        }

        // PUT: api/ReleaseDatesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReleaseDate(Guid id, ReleaseDate releaseDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != releaseDate.ReleaseID)
            {
                return BadRequest();
            }

            db.Entry(releaseDate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReleaseDateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReleaseDatesAPI
        [ResponseType(typeof(ReleaseDate))]
        public IHttpActionResult PostReleaseDate(List<ReleaseDate> releaseDates)
        {
            foreach (ReleaseDate releaseDate in releaseDates)
            {
                if (releaseDate.DateType == "KT")
                {
                    //releaseDate.StartDateTime = releaseDate.StartDateTime.AddHours(14);
                    releaseDate.EndDateTime = releaseDate.StartDateTime;
                    releaseDate.EndDateTime = releaseDate.EndDateTime.AddHours(1);
                }
                else if (releaseDate.DateType == "PKG")
                {
                    //releaseDate.StartDateTime = releaseDate.StartDateTime.AddHours(8);
                    releaseDate.EndDateTime = releaseDate.StartDateTime;
                    releaseDate.EndDateTime = releaseDate.EndDateTime.AddHours(1);

                }
                else if (releaseDate.DateType == "PP")
                {
                    //releaseDate.StartDateTime = releaseDate.StartDateTime.AddHours(9);
                    releaseDate.EndDateTime = releaseDate.StartDateTime;
                    releaseDate.EndDateTime = releaseDate.EndDateTime.AddHours(6);
                }
                else if (releaseDate.DateType == "LIVE")
                {
                    //releaseDate.StartDateTime = releaseDate.StartDateTime.AddHours(11);
                    releaseDate.EndDateTime = releaseDate.StartDateTime;
                    releaseDate.EndDateTime = releaseDate.EndDateTime.AddHours(8);
                }
                else if (releaseDate.DateType == "DNS")
                {
                    //releaseDate.StartDateTime = releaseDate.StartDateTime.AddHours(11);
                    releaseDate.EndDateTime = releaseDate.StartDateTime;
                    releaseDate.EndDateTime = releaseDate.EndDateTime.AddHours(4);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.ReleaseDates.Add(releaseDate);
            }
           

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
                //if (ReleaseDateExists(releaseDate.ReleaseID))
                //{
                //    return Conflict();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return CreatedAtRoute("DefaultApi", new { id = Guid.Empty}, new ReleaseDate());
        }

        // DELETE: api/ReleaseDatesAPI/5
        [ResponseType(typeof(ReleaseDate))]
        public IHttpActionResult DeleteReleaseDate(Guid id)
        {
            ReleaseDate releaseDate = db.ReleaseDates.Find(id);
            if (releaseDate == null)
            {
                return NotFound();
            }

            db.ReleaseDates.Remove(releaseDate);
            db.SaveChanges();

            return Ok(releaseDate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReleaseDateExists(Guid id)
        {
            return db.ReleaseDates.Count(e => e.ReleaseID == id) > 0;
        }
    }
}