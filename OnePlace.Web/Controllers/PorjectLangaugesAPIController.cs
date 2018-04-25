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
    public class PorjectLangaugesAPIController : ApiController
    {
        private OnePlaceEntities db = new OnePlaceEntities();

        // GET: api/PorjectLangaugesAPI
        public IQueryable<PorjectLangauge> GetPorjectLangauges()
        {
            return db.PorjectLangauges;
        }

        // GET: api/PorjectLangaugesAPI/5
        [ResponseType(typeof(PorjectLangauge))]
        public IHttpActionResult GetPorjectLangauge(Guid id)
        {
            PorjectLangauge porjectLangauge = db.PorjectLangauges.Find(id);
            if (porjectLangauge == null)
            {
                return NotFound();
            }

            return Ok(porjectLangauge);
        }

        // PUT: api/PorjectLangaugesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPorjectLangauge(Guid id, PorjectLangauge porjectLangauge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != porjectLangauge.ProjectID)
            {
                return BadRequest();
            }

            db.Entry(porjectLangauge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PorjectLangaugeExists(id))
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

        // POST: api/PorjectLangaugesAPI
        [ResponseType(typeof(PorjectLangauge))]
        public IHttpActionResult PostPorjectLangauge(PorjectLangauge porjectLangauge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PorjectLangauges.Add(porjectLangauge);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PorjectLangaugeExists(porjectLangauge.ProjectID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = porjectLangauge.ProjectID }, porjectLangauge);
        }

        // DELETE: api/PorjectLangaugesAPI/5
        [ResponseType(typeof(PorjectLangauge))]
        public IHttpActionResult DeletePorjectLangauge(Guid id)
        {
            PorjectLangauge porjectLangauge = db.PorjectLangauges.Find(id);
            if (porjectLangauge == null)
            {
                return NotFound();
            }

            db.PorjectLangauges.Remove(porjectLangauge);
            db.SaveChanges();

            return Ok(porjectLangauge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PorjectLangaugeExists(Guid id)
        {
            return db.PorjectLangauges.Count(e => e.ProjectID == id) > 0;
        }
    }
}