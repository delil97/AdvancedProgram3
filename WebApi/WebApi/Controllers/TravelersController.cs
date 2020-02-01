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
using WebApi;

namespace WebApi.Controllers
{
    public class TravelersController : ApiController
    {
        private TravelModel db = new TravelModel();

        // GET: api/Travelers
        public IQueryable<Travelers> GetTravelers()
        {
            return db.Travelers;
        }

        // GET: api/Travelers/5
        [ResponseType(typeof(Travelers))]
        public IHttpActionResult GetTravelers(int id)
        {
            Travelers travelers = db.Travelers.Find(id);
            if (travelers == null)
            {
                return NotFound();
            }

            return Ok(travelers);
        }

        // PUT: api/Travelers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTravelers(int id, Travelers travelers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != travelers.Id)
            {
                return BadRequest();
            }

            db.Entry(travelers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelersExists(id))
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

        // POST: api/Travelers
        [ResponseType(typeof(Travelers))]
        public IHttpActionResult PostTravelers(Travelers travelers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Travelers.Add(travelers);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = travelers.Id }, travelers);
        }

        // DELETE: api/Travelers/5
        [ResponseType(typeof(Travelers))]
        public IHttpActionResult DeleteTravelers(int id)
        {
            Travelers travelers = db.Travelers.Find(id);
            if (travelers == null)
            {
                return NotFound();
            }

            db.Travelers.Remove(travelers);
            db.SaveChanges();

            return Ok(travelers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TravelersExists(int id)
        {
            return db.Travelers.Count(e => e.Id == id) > 0;
        }
    }
}