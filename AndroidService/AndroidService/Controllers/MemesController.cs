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
using AndroidService.Models;

namespace AndroidService.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MemesController : ApiController
    {
        private AndroidServiceContext db = new AndroidServiceContext();

        // GET: api/Memes
        public IQueryable<Meme> GetMemes()
        {
            return db.Memes;
        }

        // GET: api/Memes/5
        [ResponseType(typeof(Meme))]
        public IHttpActionResult GetMeme(int id)
        {
            Meme meme = db.Memes.Find(id);
            if (meme == null)
            {
                return NotFound();
            }

            return Ok(meme);
        }

        // PUT: api/Memes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeme(int id, Meme meme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meme.MemeID)
            {
                return BadRequest();
            }

            db.Entry(meme).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemeExists(id))
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

        // POST: api/Memes
        [ResponseType(typeof(Meme))]
        public IHttpActionResult PostMeme(Meme meme)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Memes.Add(meme);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meme.MemeID }, meme);
        }

        // DELETE: api/Memes/5
        [ResponseType(typeof(Meme))]
        public IHttpActionResult DeleteMeme(int id)
        {
            Meme meme = db.Memes.Find(id);
            if (meme == null)
            {
                return NotFound();
            }

            db.Memes.Remove(meme);
            db.SaveChanges();

            return Ok(meme);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemeExists(int id)
        {
            return db.Memes.Count(e => e.MemeID == id) > 0;
        }
    }
}