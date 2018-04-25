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
using System.Data.Entity.Core.Objects;

namespace OnePlace.Web.Controllers
{
    public class ProjectsAPIController : ApiController
    {
        private OnePlaceEntities db = new OnePlaceEntities();

        // GET: api/ProjectsAPI
        public IQueryable<Project> GetProjects()
        {
            var value =  db.GetReleaseDetails().ToList();
            foreach (GetReleaseDetails_Result item in value)
            {
                var v = item.ReleaseID;
            }

            return db.Projects;
        }

        // GET: api/ProjectsAPI/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(Guid id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/ProjectsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(Guid id, Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.ProjectID)
            {
                return BadRequest();
            }

            db.Entry(project).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/ProjectsAPI
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Projects.Add(project);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProjectExists(project.ProjectID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = project.ProjectID }, project);
        }

        // DELETE: api/ProjectsAPI/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(Guid id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(Guid id)
        {
            return db.Projects.Count(e => e.ProjectID == id) > 0;
        }
    }
}