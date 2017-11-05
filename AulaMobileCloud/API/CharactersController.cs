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
using AulaMobileCloud.Models;
using AulaMobileCloud.Models.Contexto;

namespace AulaMobileCloud.API
{
    public class CharactersController : ApiController
    {
        private Contexto db = new Contexto();

        // GET: api/Characters
        public IQueryable<Characters> GetCharacter()
        {
            return db.Character;
        }

        // GET: api/Characters/5
        [ResponseType(typeof(Characters))]
        public IHttpActionResult GetCharacters(int id)
        {
            Characters characters = db.Character.Find(id);
            if (characters == null)
            {
                return NotFound();
            }

            return Ok(characters);
        }

        // PUT: api/Characters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCharacters(int id, Characters characters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != characters.Id)
            {
                return BadRequest();
            }

            db.Entry(characters).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharactersExists(id))
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

        // POST: api/Characters
        [ResponseType(typeof(Characters))]
        public IHttpActionResult PostCharacters(Characters characters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Character.Add(characters);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = characters.Id }, characters);
        }

        // DELETE: api/Characters/5
        [ResponseType(typeof(Characters))]
        public IHttpActionResult DeleteCharacters(int id)
        {
            Characters characters = db.Character.Find(id);
            if (characters == null)
            {
                return NotFound();
            }

            db.Character.Remove(characters);
            db.SaveChanges();

            return Ok(characters);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CharactersExists(int id)
        {
            return db.Character.Count(e => e.Id == id) > 0;
        }
    }
}