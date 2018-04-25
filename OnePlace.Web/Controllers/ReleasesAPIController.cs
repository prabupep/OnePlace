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
using OnePlace.Web.Models;

namespace OnePlace.Web.Controllers
{
    public class ReleasesAPIController : ApiController
    {
        private OnePlaceEntities db = new OnePlaceEntities();

        // GET: api/ReleasesAPI
        public IQueryable<Release> GetReleases()
        {
            return db.Releases;
        }

        // GET: api/ReleasesAPI/5
        [ResponseType(typeof(Release))]
        public IHttpActionResult GetRelease(Guid id)
        {
            Release release = db.Releases.Find(id);
            if (release == null)
            {
                return NotFound();
            }

            return Ok(release);
        }

        // PUT: api/ReleasesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRelease(Guid id, Release release)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != release.ReleaseID)
            {
                return BadRequest();
            }

            db.Entry(release).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReleaseExists(id))
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

        // POST: api/ReleasesAPI
        [ResponseType(typeof(Release))]
        public IHttpActionResult PostRelease(Release release)
        {
            release.ReleaseID = CommonModel.GetNewGUIDIfEmpty(release.ReleaseID);
            release= CommonModel.AssigneLoginInfo<Release>(release);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Releases.Add(release);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ReleaseExists(release.ReleaseID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = release.ReleaseID }, release);
        }

        // DELETE: api/ReleasesAPI/5
        [ResponseType(typeof(Release))]
        public IHttpActionResult DeleteRelease(Guid id)
        {
            Release release = db.Releases.Find(id);
            if (release == null)
            {
                return NotFound();
            }

            db.Releases.Remove(release);
            db.SaveChanges();

            return Ok(release);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReleaseExists(Guid id)
        {
            return db.Releases.Count(e => e.ReleaseID == id) > 0;
        }
    }
}