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
    public class LanguagesAPIController : ApiController
    {
        private OnePlaceEntities db = new OnePlaceEntities();

        // GET: api/LanguagesAPI
        public IQueryable<Language> GetLanguages()
        {
            
            return db.Languages;
        }

        // GET: api/LanguagesAPI/5
        [ResponseType(typeof(Language))]
        public IHttpActionResult GetLanguage(Guid id)
        {
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return NotFound();
            }

            return Ok(language);
        }

        // PUT: api/LanguagesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLanguage(Guid id, Language language)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != language.LanguageID)
            {
                return BadRequest();
            }

            db.Entry(language).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
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

        // POST: api/LanguagesAPI
        [ResponseType(typeof(Language))]
        public IHttpActionResult PostLanguage(Language language)
        {
            language.LanguageID = CommonModel.GetNewGUIDIfEmpty(language.LanguageID);
            //release = CommonModel.AssigneLoginInfo<Release>(release);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Languages.Add(language);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LanguageExists(language.LanguageID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = language.LanguageID }, language);
        }

        // DELETE: api/LanguagesAPI/5
        [ResponseType(typeof(Language))]
        public IHttpActionResult DeleteLanguage(Guid id)
        {
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return NotFound();
            }

            db.Languages.Remove(language);
            db.SaveChanges();

            return Ok(language);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LanguageExists(Guid id)
        {
            return db.Languages.Count(e => e.LanguageID == id) > 0;
        }
    }
}