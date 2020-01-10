using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using WebAPI.Models;
using WebAPI.Models.HelperModels;

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class osebeController : ApiController
    {
        private OsebaEntities db = new OsebaEntities();

        // GET: api/osebas
        public OsebeFormatted Getosebas()
        {
            OsebeFormatted osebe = new OsebeFormatted(db.osebas.Count(), db.osebas);
            return osebe;
        }

        // GET: api/osebas/5
        [ResponseType(typeof(oseba))]
        public IHttpActionResult Getoseba(int id)
        {
            oseba oseba = db.osebas.Find(id);
            if (oseba == null)
            {
                return NotFound();
            }

            return Ok(oseba);
        }

        // PUT: api/osebas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putoseba(int id, oseba oseba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != oseba.id_oseba)
            {
                return BadRequest();
            }

            db.Entry(oseba).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!osebaExists(id))
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

        // POST: api/osebas
        [ResponseType(typeof(oseba))]
        public IHttpActionResult Postoseba(oseba oseba)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.osebas.Add(oseba);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = oseba.id_oseba }, oseba);
        }

        // DELETE: api/osebas/5
        [ResponseType(typeof(oseba))]
        public IHttpActionResult Deleteoseba(int id)
        {
            oseba oseba = db.osebas.Find(id);
            if (oseba == null)
            {
                return NotFound();
            }

            db.osebas.Remove(oseba);
            db.SaveChanges();

            return Ok(oseba);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool osebaExists(int id)
        {
            return db.osebas.Count(e => e.id_oseba == id) > 0;
        }
    }
}